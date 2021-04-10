# KrakenTown

Well, I hope everything got commited correctly :) So this is the final version of my project, KrakenTown.
Since the video can only have less than 100MB I decided to sum everything up quickly in there and go into a little more detail here.

The game takes place underwater and follows the player trying to rise up through the levels closer toward the top of the ocean. Each level is visually seperated from the next by the 
algae-barriers which the player can never pass through; except for the gap in between, but only after collecting 3 keys each level. 
In the final, third level, the player is attacked by an evil ship trying to shoot him with motoroil.
I chose the environment because of the dynamic possibilty of the player swimming upwards and the camera following him, also because I think the background images give it a good ambiente.

First, the player. I really liked the idea of him being a Kraken, because they can "shoot" ink - which fits the idea organically. (Maybe I was also slightly influenced by the GitKraken design haha.)
Although originally I wanted to make the player as an object on blender, that didn't quite work out. Neither in the asset store nor anywhere else I found a 3D model 
of a kraken that I preferred, so I decided to keep the player as a cube with an image. I considered simply using another sea creature (like the humpback whale), 
but I feel like the aesthetic I chose is my best fitting option in the end. 

Secondly, the things the player shoots at. I decided to use objects that came to mind that are polluting the oceans and obviously I thought of plastic first. 
I decided to use the gas bottles instead, because they were visually more appealing. In the second level, the player is attacked by old boots (like sometimes get pulled out
of a lake by people going fishing). To make some attacking objects more dangerous than others, the "glass" bottles shatter and thereby may harm the player, 
and the old boots lose ("shoot") pieces of algae. Also, the jellyfish are harmful to the player as well, and they switch sides from with they appear.
All objects damaging the player have a diffrent impact on how much lives he loses.

Then, the collectibles. They appear as shiny corals. Some of them help the player by directly giving him temporarily more powerful weapon abilities like:
SuperInk that grows after shot, the ShockWave travelling up and destroying everything naught jellyfish (but the player can shoot less often after using that),
the Tsunami Bubble that explodes and hits everything within its reach, and the GlowSticks that rotate wildly to get rid of the attackers.
There are also "soft" powerups like both a shield attached to the player and one thats local and stays until its hit, Drachmen that can be collected for extra credit,
and extra lives. Since some PowerUps are way stronger than others, they get spawned seperatley.
There are also Fake PowerUps that instead of benefitting the player make him lose advantage instead, like slower movment or minus points.

Depending on how the game ends, the player eiter gets informed that he has won the game and saved the whales or failed and the oceans are now polluting further.
Both the play time and the score are shown at the end.

Things that I feel might be fun to add to the game in the future are: a StartScreen with a <Start Game> Button and something like a ScoreBoard at the end. It might also look
pretty cool to rotate the Sticks more like throwing stars. Also, a next level thats reachable after the ship is defeated, but this time there are more algae-obstacles,
not just as seperating barriers but as things the player isn't allowed to get to close to. That would make the game not just a shooting game but also make it necessary to do
some fun manouvering.

I have also added the gameplay video with explanation to this repository and its here:
https://github.com/dorokey/KrakenTown/blob/finalCommit/KrakenTown%20gameplay%20%2B%20short%20explanation.mp4

All in all, thank you for your attention :) 

Some other very short videos to sum things up visually haha:
shockwave:
https://github.com/dorokey/KrakenTown/blob/finalCommit/KrakenTown%20shockwave.mp4 
rotating glow stick barrier:
https://github.com/dorokey/KrakenTown/blob/finalCommit/rotating%20glow%20stick%20barrier.mp4 
ship and end of level 2: 
https://github.com/dorokey/KrakenTown/blob/finalCommit/KrakenTown%20end%20of%20level%202%20%2B%20ship.mp4 
