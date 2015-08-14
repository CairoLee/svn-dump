<?php

	class BaseException extends Exception {
		
		protected $logDir = null;
		protected $enableLog = true;
		protected $formattedTrace = '';
		protected $baseException = __CLASS__;
		protected $tenplateName = 'base';

		
		public function __construct($Message, $Code = 0) {
			parent::__construct($Message, $Code);

			if ($this->logDir === null) {
				$this->logDir = FRAMEWORK_DIR_ABS . '/logs/';
			}
		
			if (Framework::getTpl()) {
				$this->parseStacktrace();
			}
		}

		
		protected function parseStacktrace() {
			if (count($this->getTrace()) == 0) {
				$this->formattedTrace = 'No stacktrace available';
				return;
			}

			$result = '';
			$lineCount = strlen((string)count($this->getTrace()));
			$i = 1;
			foreach ($this->getTrace() as $trace) {
				$lineNo = str_pad($i, $lineCount, ' ', STR_PAD_LEFT);
				$line = '<font color="darkred">'.$lineNo.'</font> ';
				$line .= '<strong><font color="blue">'.$trace['function'].'</font></strong>(';
				
				if (isset($trace['args']) == true && count($trace['args']) > 0) {
					foreach ($trace['args'] as $key => $value) {
						if (is_integer($value) == true) {
							$trace['args'][$key] = '<font color="blue">' . $value . '</font>';
						} else if (is_float($value) == true) {
							$trace['args'][$key] = '<font color="#FF99FF">' . $value . '</font>';
						} else if (is_string($value) == true) {
							$trace['args'][$key] = '<font color="darkblue">\'' . $value . '\'</font>';
						} else if (is_array($value) == true) {
							$trace['args'][$key] = '<font color="#990099">(Array[' . count($value) . '])</font>';
						} else if (is_resource($value) == true) {
							$trace['args'][$key] = '<font color="#555555">(Resource, ' . $value->getType() . ')</font>';
						} else if (is_object($value) == true) {
							$trace['args'][$key] = '<font color="#009900">(Object, ' . $value->getType() . ')</font>';
						}
					}

					$line .= implode(', ', $trace['args']);
				}
				
				$basename = basename(str_replace('\\', '/', $trace['file']));
				$line .= ') -> <font color="green">' . $basename . '</font>(' . $trace['line'] . ')<br />';
				$result .= $line;
				$i++;
				$trace = NULL;
			}

			$this->formattedTrace = $result;				
		}
		

		public function __toString() {
			if ($this->getLogging() == true) {
				$this->saveLog();
			}

			if (Framework::getTpl()) {
				Framework::getTpl()->assign('exception', $this);
				Framework::getTpl()->assign('returnLink', (isset($_SERVER['HTTP_REFERER']) == true && empty($_SERVER['HTTP_REFERER']) == false ? $_SERVER['HTTP_REFERER'] : ''));
				$output = Framework::getTpl()->fetch('exception/' . $this->tenplateName . '.tpl');
				echo $output;
			} else {
				echo parent::__toString();
			}
			exit;
		}

		
		protected function saveLog() {
			$errLog = 'Error in ' . $this->getFile() . ' on line ' . $this->getLine() . PHP_EOL;
			$errLog .= 'Exception called: ' . $this->getBaseException() . ' (Code ' . $this->getCode() . ')' . PHP_EOL . PHP_EOL;
			$errLog .= 'Error Message: ' . PHP_EOL;
			$errLog .= str_replace('<br />', PHP_EOL, $this->getMessage()) . PHP_EOL . PHP_EOL;
			$errLog .= 'Stacktrace:' . PHP_EOL;
			$errLog .= strip_tags(str_replace('<br />', PHP_EOL, $this->getFormattedTrace()));
			
			do {
				$dirpath = $this->getLogDir() . $this->getBaseException() . '/';
				$filename = 'Error_' . time() . '_' . uniqid(rand(0, 99999)) . '.log'; // append unique name
			} while (file_exists($dirpath . $filename) == true);

			if (is_dir($dirpath) == false) {
				mkdir($dirpath, 0755);
			}
			$h = fopen($dirpath . $filename, 'w');
			fwrite($h, $errLog);
			fclose($h);

			return true;
		}


		
		protected function setBaseException($Exception) {
			$this->baseException = $Exception;
		}

		public function getBaseException() {
			return $this->baseException;
		}

		public function getFormattedTrace() {
			return $this->formattedTrace;
		}

		public function getLogDir() {
			return $this->logDir;
		}

		public function getLogging() {
			return $this->enableLog;
		}

		protected function setLogging($dir = 'logs/', $enabled = true) {
			$this->enableLog = $enabled;
			$this->logDir = $dir;

			if ($this->getLogging() == true) {
				// Ensure directories
				if (is_dir($this->getLogDir()) == false) {
					if (mkdir($this->getLogDir()) == false) {
						// don't use SystemException here..
						throw new Exception('Failed to create Directory ' . $this->getLogDir());
					}
				}
				if (is_dir($this->getLogDir() . $this->getBaseException()) == false) {
					if (mkdir($this->getLogDir() . $this->getBaseException()) == false) {
						throw new Exception('Failed to create Directory ' . $this->getLogDir() . $this->getBaseException() . '/');
					}
				}
			}
		}

	}

?>