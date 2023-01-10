# Shopkeeper
Shopkeeper game made for interview

ShopKeeper Sim Documentation and Thought Process.
By Guillermo Alfredo Garcia Manjarrez

First I should start explaining the mechanics of the game as well as the final point of it, as I didn’t have time to get a tutorial in the game.

ShopKeeper Sim is a simulation game where you strive to create a clothing shop to your needs, the two main mechanics of the game is placing common Objects and Stands, the first of those are purely cosmetic, but they may attract the attention of the clients giving you more popularity points for your shop, if you have more popularity points it’s easier for clients to get attracted more and buy more, the later work as displays for the cloths that you sell, you can customize them with all the cloths available in the game and if a client takes special attention in them they will buy the outfit and try it on the spot, this will give you money as well as popularity points, and no need to set a new costume, they stay in sale as long as you leave them, although try different combinations, the more exotic the costume the more likely it is to sell.

So to put it in a few words, you buy objects and displays to decorate your shop and to gain more money and popularity points so that you can keep buying things and making sell easier, all well and good but what’s the different point between other games? 
Well, what makes ShopKeeper Sim different is the sheer amount of customization options that you have available. There are over 450 different kinds of customization options for the characters including , different body types, eyes, outfits, hairstyles and accessories, every one of them fully animated so that you the main player or any NPC can wear any combination of it. And that’s not all there are over 4000 different kind of objects that you can place in the map, so what makes Shopkeeper different is the ability to customize your shop any way you like with a ton of assets.

Next I’ll explain the thought process behind the game, Shopkeeper Sim idea was born by the premise that I wanted to make something different from the usual game, something big that you could customize with a ton of things, something that demonstrated my abilities as a programmer and I must say, it was a mad race against time, with a lot of time going into a lot of different systems, the main problem was to create the tools to be able to takes this massive artist asset that I had laying around, and convert it in something I could use to develop the game, so from mundane tools like auto-naming scripts made with python so that every asset had a name that I could use [0-1-2-etc] to tools that sliced the textures automatically and custom animation scripts inside Unity I had to create a lot of custom tools and scripts to manage the massive task of bringing so many assets together for the game.

Now, I will be the one first to recognize the shortcomings of the game, the game loops is not at all polished, the UI leaves a lot to be desired and there are some key elements missing like dialogue and the ability to customize prices, and although it is not an excuse it’s derived from the time it took me to develop most of the other systems.

So, we have talked about the tools to bring the massive asset to the game but what other systems compromise it?

Well the game is based and powered by a very powerful grid system that manages from the A* pathfinding algorithm that all of the characters use to the placement of objects that let’s me decouple that from the other systems, I just need to check which tiles are occupied and wich doesn’t.

The grid system also works as a basis for the UI system, whenever you click on a part of the map the grid recognizes the type of tile you’re clicking and it can give you the necessary information to bring up the correct menus along with all the other information to manage the necessary task for the menu system, the system is pretty powerful and easily extendable so that you can create new kinds of menus and objects types easily and all of the older menus will work with the new menus seamlessly.

The last two parts are the IA and the game loop manager, the IA is again powered by the same A* pathfinding algorithm that the player character also uses, and it automatically on Instantiation searches for it’s objectives, that leaves the game loop manager to the only tasks of managing the Instantiation of the IA Characters and take acer of basic loop mechanics, as well as the saving and loading of the game.

ShopKeeper Sim is an amalgamation of systems that work together to bring a powerful system of customization to a game, it may have evolved more into a build your house game but I tried to include as many shopping mechanics as I could given the time. 
It would be a disservice to the game to say that it is a simple shopkeeping game, in certain areas it is more and in certain areas it is less, all I can say Is I gave it my all to the very last moment to create something I’m proud of.

I hope you enjoy playing it as much as I enjoyed creating it.
