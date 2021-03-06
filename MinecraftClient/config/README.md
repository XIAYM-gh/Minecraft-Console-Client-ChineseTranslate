Minecraft Console Client 用户使用手册
======

**感谢下载MCC汉化版!**

MCC是一款可以进入离线/正版MC服务器的程序
它可以在不打开MC游戏的情况下进入服务器聊天/发送命令!

如何使用
------

在Windows上，双击运行"MinecraftClientCN.exe"

使用配置文件操作机器人
------

使用文本编辑器打开MinecraftClient.ini并且修改东西
加载自动模块(AutoCraft等)后，您仍然可以发送和接收聊天消息。
你可以删除或不填写一些项来使用默认设置
你可以拥有多个INI文件，并将其中之一拖放到主程序上!

使用CMD启动MCC
------

**程序名.exe 用户名 密码 服务器ip**

这将自动的连接到这个服务器ip
如果要连接到离线服务器，请将密码填写为"-"

**程序名.exe 用户名 密码 服务器ip "/mycommand"**

将会在执行完"/mycommand"后自动退出
要发送多个命令并保持连接状态，请改用脚本

**程序名.exe myconfig.ini**

运行后将会自动读取myconfig.ini里的内容

交互命令
------

这些是MCC自带的命令,
可以使用/quit直接退出服务器并关闭程序

 - quit 或 exit: 退出服务器并关闭程序
 - reco [account] : 将会重新连接服务器
 - connect <server> [account] : 连接到指定的服务器
 - script <script name\> : 执行脚本文件
 - send <text> : 向服务器发送消息或命令
 - respawn : 死亡之后输入可以重生
 - log <text> : 向控制台发送信息(非服务端)
 - list : 显示服务器在线的玩家
 - set varname=value : 设置一个变量
 - wait <time> : 等待xxx tick (10tick=1s)
 - move : 移动
 - look : 摆头
 - debug : 调试信息
 - help : 查看帮助

[account] is an account alias defined in accounts file, read more below.
<server> is either a server IP or a server alias defined in servers file

Servers和Accounts文件
------

These two files can be used to store info about accounts and server, and give them aliases.
The purpose of this is to give them an easy-to-remember alias and to avoid typing account passwords.
As what you are typing can be read by the server admin if using the remote control feature,
using aliases is really important for privacy and for safely switching between accounts.
To use these files, simply take a look at sample-accounts.txt and sample-servers.txt.
Once you have created your files, fill the 'accountlist' and 'serverlist' fields in INI file.

与Minecraft世界交互
------

By default, Minecraft Console Client cannot interact with the world around you.
However for some versions of the game you can enable the terrainandmovements setting.

This feature will allow you to properly fall on ground, pickup items and move around.
There is a C# API for reading terrain data around the player and moving from C# scripts.

Please note that this requires much more RAM to store all the terrain data, a bit more CPU
to process all of this, and slightly more bandwidth as locations updates are
sent back to the server in a spammy way (that's how Minecraft works).

如何写一个脚本文件
------

A script file can be launched by using /script <filename> in the client's command prompt.
The client will automatically look for your script in the current directory or "scripts" subfolder.
If the file extension is .txt or .cs, you may omit it and the client will still find the script.

Regarding the script file, it is a text file with one instruction per line.
Any line beginning with "#" is ignored and treated as a comment.
Allowed instructions are given in "Internal commands" section.

Application variables defined using the 'set' command or [AppVars] INI section can be used.
The following read-only variables can also be used: %username%, %login%, %serverip%, %serverport%

如何写一个c#脚本文件
------

If you are experienced with C#, you may also write a C# script.
That's a bit more involved, but way more powerful than regular scripts.
You can look at the provided sample C# scripts for getting started.

C# scripts can be used for creating your own ChatBot without recompiling the whole project.
These bots are embedded in a script file, which is compiled and loaded on the fly.
ChatBots can access plugin channels for communicating with some server plugins.

For knowing everything the API has to offer, you can look at CSharpRunner.cs and ChatBot.cs.
The latest version for these files can be found on the GitHub repository.

The structure of the C# file must be like this:
```csharp
//MCCScript 1.0

MCC.LoadBot(<instance of your class which extends the ChatBot class>);

//MCCScript Extensions

<your class code here>
```
The first line always needs to be "//MCCScript 1.0" comment, as the program requires it to determine the version of the script.
Everything between "//MCCScript 1.0" and "//MCCScript Extensions" comments will be treated as code, that part of the code will be inserted into the constructor during the compile time.
You can include C# libraries/namespaces using the following syntax: //using <name>;
Example: //using System.Net;

使用HTTP/Socks代理
------

If you are on a restricted network you might want to use some HTTP or SOCKS proxies.
To do so, find a proxy, enable proxying in INI file and fill in the relevant settings.
Proxies with username/password authentication are supported but have not been tested.
Not every proxy will work for playing Minecraft, because of port 80/443 web browsing restrictions.
However you can choose to use a proxy for login only, most proxies should work in this mode.

连接一个禁Ping的服务器
------

On some servers, the server list ping feature has been disabled, which prevents Minecraft Console Client
from pinging the server to determine the Minecraft version to use. To connect to this kind of servers,
find out which Minecraft version is running on the server, and fill in the 'mcversion' field in INI file.
This will disable the ping step while connecting, but requires you to manually provide the version to use.
Recent versions of Minecraft Console Client may also prompt you for MC version in case of ping failure.

关于MC语言文件
------

When connecting to 1.6+ servers, you will need a translation file to display properly some chat messages.
These files describe how some messages should be printed depending on your preferred language.
The client will automatically load en_GB.lang from your Minecraft folder if Minecraft is installed on your
computer, or download it from Mojang's servers. You may choose another language in the configuration file.

检测聊天信息
------

Minecraft Console Client can parse messages from the server in order to detect private and public messages.
This is useful for reacting to messages eg when using the AutoRespond, Hangman game, or RemoteControl bots.
However, for unusual chat formats, so you may need to tinker with the ChatFormat section of the config file.
Building regular expressions can be a bit tricky, so you might want to try them out eg on regex101.com

关于Replay模组的特性
------
Replay Mod is _A Minecraft Mod to record, relive and share your experience._ You can see more at https://www.replaymod.com/

MCC support recording and saving your game to a file which can be used by Replay Mod. You can simply enable ReplayMod in the `.ini` setting to use this feature. The only limitation is the client player (you) will not be shown in the replay. Please be reminded that you MUST exit MCC with `/quit` command or use `/replay stop` command before closing MCC. Your replay will be lost if you force-closed MCC (i.e. Ctrl+C).

使用Alert
------

Write in alerts.txt the words you want the console to beep/alert you on.
Write in alerts-exclude.txt the words you want NOT to be alerted on.
For example write Yourname in alerts and <Yourname> in alerts-exclude.txt

使用AutoRelog
------

Write in kickmessages.txt some words, such as "Restarting" for example.
If the kick message contains one of them, you will automatically be re-connected.
A kick message "Connection has been lost." is generated by the console itself when connection is lost.
A kick message "Login failed." is generated the same way when it failed to login to the server.
A kick message "Failed to ping this IP." is generated when it failed to ping the server.
You can use them for reconnecting when connection is lost or the login failed.
If you want to always reconnect, set ignorekickmessage=true in MinecraftClient.ini. Use at own risk!

使用Script Scheduler
------

The script scheduler allows you to perform scripts on various events.
Simply enable the ScriptScheduler bot and specify a tasks file in your INI file.
Please read sample-tasks.ini for learning how to make your own task file.

使用 hangman game
------

Use "/tell <bot username> start" to start the game.
Don't forget to add your username in botowners INI setting if you want it to obey.
Edit the provided configuration files to customize the words and the bot owners.
If it doesn't respond to bot owners, read the "Detecting chat messages" section.

使用 Remote Control
------

When the remote control bot is enabled, you can send commands to your bot using whispers.
Don't forget to add your username in botowners INI setting if you want it to obey.
If it doesn't respond to bot owners, read the "Detecting chat messages" section.
Please note that server admins can read what you type and output from the bot.
They can also impersonate bot owners with /nick. See [#1142](https://github.com/ORelio/Minecraft-Console-Client/issues/1142) for more info.

To perform a command simply do the following: /tell <yourbot> <thecommand>
Where <thecommand> is an internal command as described in "Internal commands" section.
You can remotely send chat messages or commands using /tell <yourbot> send <thetext>

Remote control system can by default auto-accept /tpa and /tpahere requests from the bot owners.
Auto-accept can be disabled or extended to requests from anyone in remote control configuration.

使用AutoRespond的特性
------

The AutoRespond bot allows you to automatically react on specific chat messages or server announcements.
You can use either a string to detect in chat messages, or an advanced regular expression.
For more information about how to define match rules, please refer to sample-matches.ini

使用Auto Attack
------

The AutoAttack bot allows you to automatically attack mobs around you (precisely within radius of 4 block).
To use this bot, you will need to enable **Entity Handling** in the config file first.

使用Auto Fishing
------

The AutoFish bot can automatically fish for you.
To use this bot, you will need to enable **Entity Handling** in the config file first.
If you want to get an alert message when the fishing rod was broken, enable **Inventory Handling** in the config file.
A fishing rod with **Mending enchantment** is strongly recommended.

Steps for using this bot:
1. Hold a fishing rod and aim towards the sea before login with MCC
2. Make sure AutoFish is enabled in config file
3. Login with MCC
4. Do `/useitem` and you should see "threw a fishing rod"
5. To stop fishing, do `/useitem` again

使用Mailer
------

The Mailer bot can store and relay mails much like Essential's /mail command.

* /tell <Bot> mail [RECIPIENT] [MESSAGE]: Save your message for future delivery
* /tell <Bot> tellonym [RECIPIENT] [MESSAGE]: Same, but the recipient will receive an anonymous mail

The bot will automatically deliver the mail when the recipient is online.
The bot also offers a /mailer command from the MCC command prompt:

* /mailer getmails: Show all mails in the console
* /mailer addignored [NAME]: Prevent a specific player from sending mails
* /mailer removeignored [NAME]: Lift the mailer restriction for this player
* /mailer getignored: Show all ignored players

**CAUTION:** The bot identifies players by their name (Not by UUID!).
A nickname plugin or a minecraft rename may cause mails going to the wrong player!
Never write something to the bot you wouldn't say in the normal chat (You have been warned!)

**Mailer Network:** The Mailer bot can relay messages between servers.
To set up a network of two or more bots, launch several instances with the bot activated and the same database.
If you launch two instances from one .exe they should syncronize automatically to the same file.

使用Autocraft
------

The AutoCraft bot can automatically craft items for you as long as you have defined the item recipe.
You can get the default config by running the bot at lease once.

Useful commands description:
* /autocraft reload: Reload the config from disk. You can load your edited AutoCraft config without restarting the client.
* /autocraft resetcfg: Reset your AutoCraft config back to default. Use with care!
* /autocraft list: List all loaded recipes.
* /autocraft start <name\>: Start the crafting process with the given recipe name you had defined.
* /autocraft stop: Stop the crafting process.
* /autocraft help: In-game help command.


How to define a recipe?

_Example_
```md
[Recipe]
name=whatever          # name could be whatever you like. This field must be defined first
type=player            # crafting table type: player or table
result=StoneButton     # the resulting item

# define slots with their deserved item
slot1=stone            # slot start with 1, count from left to right, top to bottom
# For the naming of the items, please see
# https://github.com/ORelio/Minecraft-Console-Client/blob/master/MinecraftClient/Inventory/ItemType.cs
```

1. You need to give your recipe a **name** so that you could start them later by name.
2. The size of crafting area needed for your recipe, 2x2(player inventory) or 3x3(crafting table). If you need to use the crafting table, make sure to set the **table coordinate** in the `[AutoCraft]` section.
3. The expected crafting result.

Then you need to define the position of each crafting materials. 
Slots are indexed as follow:

2x2
```
╔═══╦═══╗
║ 1 ║ 2 ║
╠═══╬═══╣
║ 3 ║ 4 ║
╚═══╩═══╝
```
3x3
```
╔═══╦═══╦═══╗
║ 1 ║ 2 ║ 3 ║
╠═══╬═══╬═══╣
║ 4 ║ 5 ║ 6 ║
╠═══╬═══╬═══╣
║ 7 ║ 8 ║ 9 ║ 
╚═══╩═══╩═══╝
```
Simply use `slotIndex=MaterialName` to define material.  
 e.g. `slot1=coal` and `slot3=stick` will craft a torch.

For the naming of items, please see [ItemType.cs](https://github.com/ORelio/Minecraft-Console-Client/blob/master/MinecraftClient/Inventory/ItemType.cs).

After you finished writing your config, you can use `/autocraft start <recipe name>` to start crafting. Make sure to provide materials for your bot.

警告
------

Even if everything should work, We are not responsible for any damage this app could cause to your computer or your server.
This app does not steal your password. If you don't trust it, don't use it or check & compile from the source code.

Also, remember that when you connect to a server with this program, you will appear where you left the last time.
This means that **you can die if you log in in an unsafe place on a survival server!**
Use the script scheduler bot to send a teleport command after logging in.

We remind you that **you may get banned** by your server for using this program. Use accordingly with server rules.

协议
------

Minecraft Console Client is a totally free of charge, open source project.
Source code is available at https://github.com/ORelio/Minecraft-Console-Client

Unless specifically stated, source code is from me or contributors, and available under CDDL-1.0.
More info about CDDL-1.0: http://qstuff.blogspot.fr/2007/04/why-cddl.html
Full license at http://opensource.org/licenses/CDDL-1.0

Credits
------

Even though I'm the main author of Minecraft Console Client, many features
would not have been possible without the help of talented contributors:

**Ideas:**

  ambysdotnet, Awpocalypse, azoundria, bearbear12345, bSun0000, Cat7373, dagonzaros, Dids,
  Elvang, fuckofftwice, GeorgH93, initsuj, JamieSinn, joshbean39, LehmusFIN, maski, medxo,
  mobdon, MousePak, TNT-UP, TorchRJ, yayes2, Yoann166, ZizzyDizzyMC

**Bug Hunters:**

  1092CQ, ambysdotnet, bearbear12345, c0dei, Cat7373, Chtholly, Darkaegis, dbear20,
  DigitalSniperz, doranchak, drXor, FantomHD, gerik43, ibspa, iTzMrpitBull, JamieSinn,
  k3ldon, KenXeiko, link3321, lyze237, mattman00000, Nicconyancat, Pokechu22, ridgewell,
  Ryan6578, Solethia, TNT-UP, TorchRJ, TRTrident, WeedIsGood, xp9kus, Yoann166

**Code contributions:**

  Allyoutoo, Aragas, Bancey, bearbear12345, corbanmailloux, dbear20, dogwatch, initsuj,
  JamieSinn, justcool393, lokulin, maxpowa, medxo, milutinke, Pokechu22, ReinforceZwei,
  repository, TheMeq, TheSnoozer, vkorn, v1RuX, yunusemregul, ZizzyDizzyMC

**Libraries:**

  Minecraft Console Client also borrows code from the following libraries:

  -----------------------------------------------------------------
    Name           Purpose             Author             License
    
    Biko           Proxy handling      Benton Stark       MIT
    BouncyCastle   CFB-8 AES on Mono   The Legion         MIT
    Heijden.Dns    DNS SRV Lookup      Geoffrey Huntley   MIT
    DotNetZip      Zlib compression    Dino Chiesa        MS-PL
  -----------------------------------------------------------------

**Support:**

If you still have any question after reading this file, you can get support here:

 - General Questions: http://www.minecraftforum.net/topic/1314800-/
 - Bugs & Issues: https://github.com/ORelio/Minecraft-Console-Client/issues

Like Minecraft Console Client? You can buy me a coffee here:

 - https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=EALHERGB9DQY8

Code contributions, bug reports and any kind of comments are also highly appreciated :)

+-----------------------------------+
| © 2012-2020 ORelio & Contributors |
+-----------------------------------+
