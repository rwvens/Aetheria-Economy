# Aetheria
This repository is the home of Aetheria, which could be described as a sci-fi hybrid ARPG/RTS MMO about a group of corporations colonizing a hostile alien galaxy, with a satirical narrative critiquing late-stage capitalism.

The ARPG game design document is available [here](https://docs.google.com/document/d/1iULu1WsbuQoUM3c87XkGseb1P-8R5xlruoiyg03TsSE/edit?usp=sharing), while the RTS gameplay is documented [here](https://docs.google.com/document/d/1U3uGFqQboAiFJ_Y-nUOGpyixbXUHRbc5DiCuB59GM4w/edit?usp=sharing). The goal is to essentially create two games which both take place in the same persistent universe, allowing players with vastly different preferences to struggle together for the survival of mankind. Each instance of the game lasts until the inevitable destruction of the entire population at the hands of aliens, after which the universe resets. Each loop is designed to last up to a couple of months, during which the hostility of the aliens steadily increases until the players are unable to hold back the tide.

Previously I have built prototypes of the ARPG gameplay, [here's a video of the most recent one](https://www.youtube.com/watch?v=PNwVGtvefCg). While it included stations, AI opponents, multiple ships and a complex loadout system which simulates heat transfer between all of the ship's hardpoints with temperature affecting the performance of each item differently, the world was rather static and empty.

As a result, the current focus is on the economy system, and building a client-server architecture for the networked simulation of a persistent universe. The goal is to create an RTS client, allowing players to take the role of a corporation, where they can define roles for their population, gather resources, build infrastructure, research new technology and produce items in order to make as much money as possible.

Once we have built a persistent universe with a dynamic economy, we will begin rebuilding the ARPG client allowing the player to take control of a single ship and engage in fast-paced combat, questing and trading.

## Architecture

There are two solutions in this repository. One is a Unity project containing the desktop client for Aetheria, and the other is a .NET Core server application intended to run on Linux cloud servers. There is some code shared between them, located at [Assets/Scripts/ServerShared](Assets/Scripts/ServerShared), defining a common protocol and data serialization format. Client-Server communication is implemented using [MagicOnion](https://github.com/Cysharp/MagicOnion), an RPC framework that transmits [MessagePack](https://github.com/neuecc/MessagePack-CSharp) over the wire.

Aetheria uses [RethinkDB](https://rethinkdb.com/) for data persistence. To make this possible, all persistent data is marked with attributes for both MessagePack and [JSON.Net](https://www.newtonsoft.com/json) serialization. During operation, the client does not communicate with the database server directly, only the game server does that; the game server caches data relevant to the game and sends it to the clients.

## Database Editor Tools

In order to facilitate the creation and maintenance of game data, there is a Unity editor utility which communicates directly with RethinkDB. You can access the tools by selecting Window/Aetheria Database Tools in Unity's menu. This will cause two windows to appear, the Database List View and the Database Inspector.

#### Connecting to RethinkDB

At the top of the list view there is a text field where you can enter the URL of the database server. When you click connect, the editor will download and cache all of the items in the game, as well as subscribe to the changefeed. The list should now populate with items. For access to our database servers and therefore live game data, please contact us; it would be dangerous to make our actual database URL public!

#### Editing Items

You can unfold the categories of items in the list view to see what items exist. If you select an item, the Database Inspector will populate with all of the available fields of that item. Any changes you make in the Inspector will automatically be pushed to RethinkDB. If you've connected to the production database, this will update the stats of in-game items in real-time!

## Contact Us

If you want to chat, please join [our Discord server](https://discord.gg/trbteNj).