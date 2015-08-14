#include "Insanity.h"

struct HookEntry {
	void* funcReal;
	void* funcMine;
	void* funcJump;
	unsigned char verify[5]; 
};

class HookUtil {
private:
	std::map<std::string, HookEntry> mTable;

public:
	HookUtil( void ){
	}

	~HookUtil( void ){
	}

	void Hook( const char* name, void* origfunc, void* myfunc ){
		this->mTable[name].funcMine = myfunc;
		this->mTable[name].funcReal = origfunc;

		DetourTransactionBegin();
		DetourUpdateThread( GetCurrentThread() );
		DetourAttach( &origfunc, myfunc );
		DetourTransactionCommit();

		this->mTable[ name ].funcJump = origfunc;
		memcpy( this->mTable[ name ].verify, this->mTable[ name ].funcReal, 5 );
	}

	void Unhook( const char* name ){
		void* myfunc = this->mTable[ name ].funcMine;
		void* origfunc = this->mTable[ name ].funcJump;
		this->mTable.erase( name );

		DetourTransactionBegin();
		DetourUpdateThread( GetCurrentThread() );
		DetourDetach( &origfunc, myfunc );
		DetourTransactionCommit();
	}

	void* GetOrig( const char* name ){
		return this->mTable[ name ].funcJump;
	}

	void* GetMine( const char* name ){
		return this->mTable[ name ].funcMine;
	}

	bool Verify( void ){
		bool result = true;
		for( std::map<std::string, HookEntry>::iterator i = this->mTable.begin(); i != this->mTable.end(); ++i ){
			if( memcmp( i->second.funcReal, i->second.verify, 5 ) != 0 ){
				DWORD oldprotect;
				VirtualProtect( i->second.funcReal, 5, PAGE_READWRITE, &oldprotect );
				memcpy( i->second.funcReal, i->second.verify, 5 );
				VirtualProtect( i->second.funcReal, 5, oldprotect, &oldprotect );

				result = false;
			}
		}

		return result;
	}
};
