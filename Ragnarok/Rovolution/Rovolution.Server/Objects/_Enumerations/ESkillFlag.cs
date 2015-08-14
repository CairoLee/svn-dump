using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	public enum ESkillFlag {
		Permanent,
		Temporary,
		Plagiarized,
		ReplacedLv0, // temporary skill overshadowing permanent skill of level 'N - ReplacedLv0'
		//...
	}
}
