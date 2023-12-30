# TPRTracker

## A unity-based map tracker for TPR with spoiler log integration and hint systems

### Head over to [releases](https://github.com/AudioPixie/TPRTracker/releases) to download the latest build

**Attention Mac users:** if you are blocked from opening the application, right click the icon and select "Open", then select "Open" again in the pop-up dialog.
 
**Attention Windows users:** you can safely disregard/delete the _MACOSX folder, this is a fun result of zipping a folder on Mac that I will figure out how to get rid of at some point...

Current releases include MacOS and Windows x64 builds. Feel free to request additional versions.
 
## Application Overview

**Includes:**  

- Item tracking
	- Regular items
	- Dungeons
	- Overworld keys and vessels of light
	- Dungeon keys

- Map tracker
	- Overworld checks
	- Dungeon checks
	- Poes
	- Bugs

- Settings 
	- General settings for tracker behavior, saving, and reseting
	- Seed settings to match your generator settings
	- Visual settings for layout/cosmetic options

- Hints and spoiler log integration
	- Import your spoiler log to automatically populate settings, layout, etc.
	- 2 hint systems (see below)
	- Hints are saved with your save file

- Check marking
	- Checks can be right clicked to mark them as a **junk item** (orange) or a **key item** (blue)
	- This is purely cosmetic
	- This can be useful for marking checks you can see but can't yet obtain (e.g. bugs you can see but can't get without a clawshot, shop items you can't afford yet, checks you got hints for, etc.)
	- This is useful in **Rupee Mode** (see below) to mark junk items that you don't obtain (e.g. seeing a blue rupee that you don't want to waste time grabbing) as it visually marks it off but doesn't affect your rupee count

- Automatic Go Mode
	- The Go Mode graphic appears when you have everything needed to defeat Ganondorf
	- Click on it to make it disappear
	- If you click on it and want it back, head to General Settings to re-enable it 
	
## Hints

### Spirit of Light hints

- Generated when spoiler log is imported
- Click the spirit of light to reveal their hint
- Recommended to reveal hints when you enter the corresponding spring in-game
- Ordona and Lanayru:
	- Gives you the **item name** of a key item and the **check name** where the item is located
- Faron and Eldin
	- Gives you a **check name** that contains a key item

### Fanadi's Palace and Rupee Mode

- Looks at current progress and will give you a hint for an **available** check
- All hints you generate are kept, click **View Hints** to see your preivously generated hints. Click **Got it** to return to the shop.
- **Rupee mode:** collect rupees as you complete checks to spend on hints at Fanadi's Palace. Some checks are worth more than others! Rupee mode can be toggled in General Settings.
- This means even **junk items** can be of some use - going out of your way to pick up some arrows still means you get closer to being able to buy another hint!

#### 3 Tiers of hint
- 5 rupees: Gives you the name of an available check that contains a **junk item**
- 20 rupees: Gives you the name of a **key item** and the **region** that the (available) check is in
- 50 rupees: Gives you the name of a **key item** and the (available) **check name** where it is located

> Note: The 5 rupee tier won't give you a check in an unrequired dungeon if they are barren. It will give you the name of a check you would have otherwise considered completing so you don't have to bother.

#### Agitha and running out of hints

Agitha is completely removed from Fanadi's hints as it would require the user to check off which *specific* bugs they have collected and which *specific* bugs they have traded in for it to work, personally this sounds a bit tedious... But this has an interesting effect that is worth noting:

> *"Hmm... The spirits have gone quiet. I won't charge you, feel free to try again another time."*

Assuming you aren't in Go Mode (or checked off something you shouldn't have...), there should always be a key item you're looking for, so if Fanadi can't find it **it's very likely that Agitha has it**. 

### Key Items

Both Spirit of Light hints and Fanadi's tier 2 and 3 hints are generated from a list of **key items**. When a hint is generated, that item is removed from the list. Items in your starting inventory are excluded from this list and your settings are taken into account:

- Progressive Swords
- Progressive Bows
- Progressive Clawshots
- Progressive Fishing Rods
- Progressive Dominion Rods
- Filled Bomb Bags
- Lantern
- Boomerang
- Iron Boots
- Ball and Chain
- Spinner
- Shadow Crystal
- Zora Armor 
	- If Gifts from NPCs are in item pool
- Auru's Memo
	- If Gifts from NPCs are in item pool
- Ashei's Sketch
	- If Gifts from NPCs are in item pool
- Progressive Sky Books
	- If Sky Characters are in item pool and CitS entrance requires filled skybook. If unrequired dungeon are barren, only added if CitS is a required dungeon.
- Bulblin Camp Key
	- If Arbiter's requires it and key settings aren't vanilla
- Gate Keys
	- If key settings aren't Keysy
- Dungeon small keys
	- Only for Any Dungeon and Keysanity. Only includes required dungeons and Hyrule Castle
- Dungeon big keys
	- Only for Any Dungeon and Keysanity. Only includes required dungeons and Hyrule Castle

### Junk Items

Junk items for the 5 rupee tier are quite restricted, so don't worry about there being anything good in there:

- All rupees except silver
- All bomb types
- Arrows
- Seeds

## Current goals and community contribution

Feedback, testing, ideas, and development contributions are extremely welcome and are more than appreciated! Feel free to hit me up in the [TPR Discord](https://discord.gg/tprandomizer) if you want to chat about the tracker. Feel free to take a look at the [issues page](https://github.com/AudioPixie/TPRTracker/issues) for current bugs, future ideas, and what is currently being worked on. As of now these are the mains things I'm focusing on:

- Getting the logic rock-solid and keeping up-to-date with randomizer releases
- Getting glitched logic implemented
- Bug fixes for critical issues

Thanks for reading this far and happy tracking!


> Fun fact: this project does not contain a single ```Update()``` method
