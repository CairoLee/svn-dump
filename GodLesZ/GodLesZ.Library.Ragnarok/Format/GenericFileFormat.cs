using System;
using System.IO;
using System.Text;

namespace GodLesZ.Library.Ragnarok {

	public abstract class GenericFileFormat : IFileFormat, IDisposable {

		public BinaryReader Reader {
			get;
			internal set;
		}

		public BinaryWriter Writer {
			get;
			internal set;
		}

		public string Filepath {
			get;
			internal set;
		}

		public GenericFileFormatVersion Version {
			get;
			internal set;
		}

		public Encoding Encoding {
			get;
			internal set;
		}

		public event OnFlushHandler OnFlush;


		public GenericFileFormat()
			: this("") {
		}

		public GenericFileFormat(Encoding enc)
			: this("", enc) {
		}

		public GenericFileFormat(string filepath)
			: this(filepath, null) {
		}

		public GenericFileFormat(string filepath, Encoding enc) {
			if (enc != null) {
				Encoding = enc;
			}

			if (string.IsNullOrEmpty(filepath) == true) {
				return;
			}

			if (File.Exists(filepath) == false) {
				throw new ArgumentException("Die Datei \"" + filepath + "\" konnte nicht gefunden werden.");
			}

			Read(filepath);
		}

		public GenericFileFormat(Stream stream)
			: this(stream, null) {
		}

		public GenericFileFormat(Stream stream, Encoding enc) {
			if (enc != null) {
				Encoding = enc;
			}

			if (stream == null) {
				return;
			}

			Read(stream);
		}

		~GenericFileFormat() {
			Dispose();
		}



		public static void aFree(object obj) {
			if (obj == null) {
				return;
			}

			if (obj is IDisposable) {
				((IDisposable)obj).Dispose();
			}

			obj = null;
		}


		#region Read
		public virtual bool Read() {
			if (Reader == null) {
				return false;
			}

			return ReadInternal();
		}

		public virtual bool Read(Stream stream) {
			if (stream == null || stream.CanRead == false) {
				throw new Exception("Failed to read form stream!");
			}
			if (Encoding == null) {
				Encoding = Encoding.Default;
			}

			Filepath = null;
			Reader = new BinaryReader(stream, Encoding);

			return ReadInternal();
		}

		public virtual bool Read(string filepath) {
			if (File.Exists(filepath) == false) {
				throw new ArgumentException("File \"" + filepath + "\" not found!");
			}

			Filepath = filepath;
			Reader = new BinaryReader(File.OpenRead(filepath), Encoding);

			return ReadInternal();
		}


		protected virtual bool ReadInternal() {
			return false;
		}
		#endregion

		#region Write
		public virtual bool Write(string destinationPath) {
			return Write(destinationPath, true);
		}

		public virtual bool Write(string destinationPath, bool overwrite) {
			if (File.Exists(destinationPath) == true) {
				if (overwrite == false) {
					return false;
				}
				File.Delete(destinationPath);
			}

			Writer = new BinaryWriter(File.OpenWrite(destinationPath), Encoding);
			return true;
		}
		#endregion

		#region Flush
		public virtual void Flush() {
			Flush(false);
		}

		public virtual void Flush(bool OnDestruct) {
			if (OnFlush != null) {
				OnFlush(OnDestruct);
			}

			if (Reader != null) {
				try {
					Reader.Close();
					Reader = null;
				} catch { }
			}
			if (Writer != null) {
				try {
					Writer.Close();
					Writer = null;
				} catch { }
			}
		}
		#endregion

		public void Dispose() {
			Flush(true);
		}

	}

	public delegate void OnFlushHandler(bool OnDestruct);

}
