using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {
	
	public enum EAccountLoadResult {
		Success = 255,

		UnregisteredID = 0,
		IncorrectPassword = 1,
		AccountExpired = 2,
		RejectedFromServer = 3,
		BlockedByGM = 4,
		NotLatesEXE = 5,
		Banned = 6,
		ServerOverPopulation = 7,
		AccountLmitFromCompany = 8,
		BanByDBA = 9,
		EmailNotConfirmed = 10,
		BanByGM = 11,
		WorkingInDB = 12,
		SelfLock = 13,
		NotPermittedGroup = 14,
		NotPermittedGroup2 = 15,

		AccountGone = 99,
		LoginInfoRemains = 100,
		HackingInvestigation = 101,
		BugInvestigation = 102,
		DeletingChar = 103,
		DeletingSpouseChar = 104,

	}

}
