using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {
	
	public enum ECharacterCreationResult {
		Success = -1,
		CharnameAlreadyExists = 0x00,
		CharCreationDenied = 0xFF,
		YouAreUnderaged = 0x01
	}
}
