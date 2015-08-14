using GodLesZ.Library.MySql.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace GodLesZ.Library.MySql.Data.MySqlClient {

	internal sealed class MySqlPool {
		private AutoResetEvent autoEvent;
		private int available;
		private bool beingCleared;
		private Queue<Driver> idlePool;
		private List<Driver> inUsePool;
		private uint maxSize;
		private uint minSize;
		private GodLesZ.Library.MySql.Data.MySqlClient.ProcedureCache procedureCache;
		private MySqlConnectionStringBuilder settings;

		public MySqlPool(MySqlConnectionStringBuilder settings) {
			this.minSize = settings.MinimumPoolSize;
			this.maxSize = settings.MaximumPoolSize;
			this.available = (int)this.maxSize;
			this.autoEvent = new AutoResetEvent(false);
			if (this.minSize > this.maxSize) {
				this.minSize = this.maxSize;
			}
			this.settings = settings;
			this.inUsePool = new List<Driver>((int)this.maxSize);
			this.idlePool = new Queue<Driver>((int)this.maxSize);
			for (int i = 0; i < this.minSize; i++) {
				this.idlePool.Enqueue(this.CreateNewPooledConnection());
			}
			this.procedureCache = new GodLesZ.Library.MySql.Data.MySqlClient.ProcedureCache((int)settings.ProcedureCacheSize);
			this.beingCleared = false;
		}

		private Driver CheckoutConnection() {
			Driver driver = this.idlePool.Dequeue();
			if (!driver.Ping()) {
				driver.Close();
				driver = this.CreateNewPooledConnection();
			}
			if (this.settings.ConnectionReset) {
				driver.Reset();
			}
			return driver;
		}

		internal void Clear() {
			lock (((ICollection)this.idlePool).SyncRoot) {
				this.beingCleared = true;
				while (this.idlePool.Count > 0) {
					this.idlePool.Dequeue().Close();
				}
			}
		}

		private Driver CreateNewPooledConnection() {
			Driver driver = Driver.Create(this.settings);
			driver.Pool = this;
			return driver;
		}

		public Driver GetConnection() {
			int num = (int)(this.settings.ConnectionTimeout * 0x3e8);
			int millisecondsTimeout = num;
			DateTime now = DateTime.Now;
			while (millisecondsTimeout > 0) {
				Driver driver = this.TryToGetDriver();
				if (driver != null) {
					return driver;
				}
				if (!this.autoEvent.WaitOne(millisecondsTimeout, false)) {
					break;
				}
				millisecondsTimeout = num - ((int)DateTime.Now.Subtract(now).TotalMilliseconds);
			}
			throw new MySqlException(Resources.TimeoutGettingConnection);
		}

		private Driver GetPooledConnection() {
			Driver item = null;
			lock (((ICollection)this.idlePool).SyncRoot) {
				if (!this.HasIdleConnections) {
					item = this.CreateNewPooledConnection();
				} else {
					item = this.CheckoutConnection();
				}
			}
			lock (((ICollection)this.inUsePool).SyncRoot) {
				this.inUsePool.Add(item);
			}
			return item;
		}

		public void ReleaseConnection(Driver driver) {
			lock (((ICollection)this.inUsePool).SyncRoot) {
				if (this.inUsePool.Contains(driver)) {
					this.inUsePool.Remove(driver);
				}
			}
			if (driver.IsTooOld() || this.beingCleared) {
				driver.Close();
			} else {
				lock (((ICollection)this.idlePool).SyncRoot) {
					this.idlePool.Enqueue(driver);
				}
			}
			Interlocked.Increment(ref this.available);
			this.autoEvent.Set();
		}

		public void RemoveConnection(Driver driver) {
			lock (((ICollection)this.inUsePool).SyncRoot) {
				if (this.inUsePool.Contains(driver)) {
					this.inUsePool.Remove(driver);
					Interlocked.Increment(ref this.available);
					this.autoEvent.Set();
				}
			}
			if (this.beingCleared && (this.NumConnections == 0)) {
				MySqlPoolManager.RemoveClearedPool(this);
			}
		}

		private Driver TryToGetDriver() {
			Driver pooledConnection;
			if (Interlocked.Decrement(ref this.available) < 0) {
				Interlocked.Increment(ref this.available);
				return null;
			}
			try {
				pooledConnection = this.GetPooledConnection();
			} catch (Exception exception) {
				if (this.settings.Logging) {
					Logger.LogException(exception);
				}
				Interlocked.Increment(ref this.available);
				throw;
			}
			return pooledConnection;
		}

		public bool BeingCleared {
			get { return this.beingCleared; }
		}

		private bool HasIdleConnections {
			get { return (this.idlePool.Count > 0); }
		}

		private int NumConnections {
			get { return (this.idlePool.Count + this.inUsePool.Count); }
		}

		public GodLesZ.Library.MySql.Data.MySqlClient.ProcedureCache ProcedureCache {
			get { return this.procedureCache; }
		}

		public MySqlConnectionStringBuilder Settings {
			get { return this.settings; }
			set { this.settings = value; }
		}
	}
}

