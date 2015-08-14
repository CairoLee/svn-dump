#ifndef _ACHIEVEMENTCHECK_H_
#define _ACHIEVEMENTCHECK_H_

bool AchievementCheck_KillMob( struct map_session_data *Player, struct AchievementObject *Achieve, va_list Args );
bool AchievementCheck_KillMobRace( struct map_session_data *Player, struct AchievementObject *Achieve, va_list Args );
bool AchievementCheck_GenericCount( struct map_session_data *Player, struct AchievementObject *Achieve, va_list Args );
bool AchievementCheck_GenericCountAdd( struct map_session_data *Player, struct AchievementObject *Achieve, va_list Args );
bool AchievementCheck_GenericStatusTimer( struct map_session_data *Player, struct AchievementObject *Achieve, va_list Args );


#endif /* _ACHIEVEMENTCHECK_H_ */
