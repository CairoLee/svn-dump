#ifndef _ACHIEVEMENTRECEIVE_H_
#define _ACHIEVEMENTRECEIVE_H_


int AchievementReceive_BaseEXP( struct map_session_data *Player, struct AchievementObject *Achieve, struct AchievementDataObject *ReceiveObject, va_list Args );
int AchievementReceive_JobEXP( struct map_session_data *Player, struct AchievementObject *Achieve, struct AchievementDataObject *ReceiveObject, va_list Args );
int AchievementReceive_Zeny( struct map_session_data *Player, struct AchievementObject *Achieve, struct AchievementDataObject *ReceiveObject, va_list Args );
int AchievementReceive_Item( struct map_session_data *Player, struct AchievementObject *Achieve, struct AchievementDataObject *ReceiveObject, va_list Args );


#endif /* _ACHIEVEMENTRECEIVE_H_ */
