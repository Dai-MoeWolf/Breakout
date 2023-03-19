# 基于C# winform的打砖块小游戏
这个游戏有这么几点要求：
1. 游戏开始时，小球停在下方的档板上静止不动，如图1所示
2. 当玩家按下空格键后，小球开始向斜上方运动，
3. 如果小球碰到上方的砖块，则被碰到的砖块消失。若小球碰到窗体的上边界和左右边界，就被弹回继续做运动。
4. 玩家可以用键盘上的左右箭头键来操作档板，使其左右移动；当小球向下方运动时，如果小球碰到档板，则被档板弹回；否则，如果小球没有碰到档板，则飞出窗体下边界，这时回到游戏的初始状态（档板回到窗体下部中间位置，其上出现一个静止的小球，但砖块的数目保持不变），玩家可以再次开始游戏，直到把所有砖块打掉为止。
---
我使用的类似Unity的逻辑框架写的这个程序
下面是这个游戏实现的类图：
![](https://i.bmp.ovh/imgs/2022/03/d6a0c1577a9afe61.png)
