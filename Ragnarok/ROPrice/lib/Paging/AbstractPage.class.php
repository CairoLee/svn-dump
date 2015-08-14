<?php

	abstract class AbstractPage {
		protected $registeredTemplates = array();
		protected $template = 'index';

		public function __construct() {

		}

		
		public function loadData() {
		}


		public function show() {
			// register this template
			$this->registerTemplate($this->template);

			// display every template
			foreach ($this->getRegisteredTemplates() as $tpl) {
				if (strlen($tpl) < 4 || substr($tpl, -4) != '.tpl') {
					$tpl .= '.tpl';
				}
				Framework::getTpl()->display($tpl);
			}
		}


		public function registerTemplate($tplName) {
			$this->registeredTemplates[] = $tplName;
		}


		public function getRegisteredTemplates() {
			return $this->registeredTemplates;
		}

		public function getTpl() {
			return Framework::getTpl();
		}

		public function getDb() {
			return Framework::getDb();
		}

	}

?>