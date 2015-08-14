package Communication.VO.Guild
{
    import GuildSystem.*;

    public class dGuildPlayerPermissionVO extends Object
    {
        public var joinRequestAllow:int;
        public var kick:int;
        public var officerNote:int;
        public var invite:int;
        public var guildMail:int;
        public var officersChannel:int;
        public var motd:int;
        public var ranksAssign:int;
        public var joinRequestAccept:int;
        public var ranksEdit:int;
        public var note:int;
        public var banner:int;
        public var description:int;

        public function dGuildPlayerPermissionVO()
        {
            this.motd = PERMISSIONS.NO;
            this.description = PERMISSIONS.NO;
            this.officerNote = PERMISSIONS.NO;
            this.ranksEdit = PERMISSIONS.NO;
            this.ranksAssign = PERMISSIONS.NO;
            this.banner = PERMISSIONS.NO;
            this.guildMail = PERMISSIONS.NO;
            this.kick = PERMISSIONS.NO;
            this.invite = PERMISSIONS.NO;
            this.joinRequestAllow = PERMISSIONS.NO;
            this.joinRequestAccept = PERMISSIONS.NO;
            this.note = PERMISSIONS.NO;
            this.officersChannel = PERMISSIONS.NO;
            return;
        }// end function

        public function BannerWrite() : Boolean
        {
            return this.banner >= PERMISSIONS.WRITE ? (true) : (false);
        }// end function

        public function NoteWrite() : Boolean
        {
            return this.note >= PERMISSIONS.WRITE ? (true) : (false);
        }// end function

        public function RanksEdit() : Boolean
        {
            return this.ranksEdit >= PERMISSIONS.WRITE ? (true) : (false);
        }// end function

        public function OfficerNoteWrite() : Boolean
        {
            return this.officerNote >= PERMISSIONS.WRITE ? (true) : (false);
        }// end function

        public function JoinRequestAccept() : Boolean
        {
            return this.joinRequestAccept >= PERMISSIONS.WRITE ? (true) : (false);
        }// end function

        public function JoinRequestAllow() : Boolean
        {
            return this.joinRequestAllow >= PERMISSIONS.WRITE ? (true) : (false);
        }// end function

        public function OfficerNoteRead() : Boolean
        {
            return this.officerNote >= PERMISSIONS.READ ? (true) : (false);
        }// end function

        public function DescriptionWrite() : Boolean
        {
            return this.description >= PERMISSIONS.WRITE ? (true) : (false);
        }// end function

        public function Kick() : Boolean
        {
            return this.kick >= PERMISSIONS.WRITE ? (true) : (false);
        }// end function

        public function Invite() : Boolean
        {
            return this.invite >= PERMISSIONS.WRITE ? (true) : (false);
        }// end function

        public function GuildMail() : Boolean
        {
            return this.guildMail >= PERMISSIONS.WRITE ? (true) : (false);
        }// end function

        public function MOTDWrite() : Boolean
        {
            return this.motd >= PERMISSIONS.WRITE ? (true) : (false);
        }// end function

        public function OfficersChannel() : Boolean
        {
            return this.officersChannel >= PERMISSIONS.WRITE ? (true) : (false);
        }// end function

        public function RanksAssign() : Boolean
        {
            return this.ranksAssign >= PERMISSIONS.WRITE ? (true) : (false);
        }// end function

    }
}
