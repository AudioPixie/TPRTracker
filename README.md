# TPRTracker

## A unity-based map tracker for TPR with spoiler log integration and hint systems

### Head over to [releases](https://github.com/AudioPixie/TPRTracker/releases) to download the latest build

**Attention Racers:** automatic race options are based off of Season 1 Tournament ruleset as of: **October 29th, 2024**. Please reach out for changes.

**Attention Mac users:** if you are blocked from opening the application, right click the icon and select "Open", then select "Open" again in the pop-up dialog.
 
**Attention Windows users:** you can safely disregard/delete the _MACOSX folder, this is a fun result of zipping a folder on Mac that I will figure out how to get rid of at some point...

Current releases include MacOS and Windows x64 builds. Feel free to request additional versions.

## Application Overview

**Includes:**  

- Item tracking
	- Regular items
	- Dungeons (can be cycled with right-click)
	- Overworld keys and vessels of light
	- Dungeon keys

- Map tracker
	- Overworld checks
	- Dungeon checks
	- Poes
	- Bugs
	- Hint Signs
	- Howling Stones

- Notepad
	- For notes/in-game hints
	- Supports a custom template save/load

- Settings 
	- General settings for tracker behavior, saving, and reseting
	- Seed settings to match your generator settings
	- Visual settings for layout/cosmetic options

- Hints and spoiler log integration
	- Import your [spoiler log](https://github.com/AudioPixie/TPRTracker/tree/main?tab=readme-ov-file#spoiler-log-integration) to automatically populate settings, layout, etc.
	- 2 hint systems ([see below](https://github.com/AudioPixie/TPRTracker/tree/main?tab=readme-ov-file#hints))
	- Hints are saved with your save file

- Automatic Race Settings
	- Automatically sets up tracker for races
  	- Race item layout preset
	- Will reflect most current/used race ruleset (see details [here](https://github.com/AudioPixie/TPRTracker/tree/main?tab=readme-ov-file#automatic-race-settings))

- Check marking
	- Checks can be right clicked to mark them as a **junk item** (orange) or a **key item** (blue)
	- This is purely cosmetic and included in your save file
	- This can be useful for marking checks you can see but can't yet obtain (e.g. bugs you can see but can't get without a clawshot, shop items you can't afford yet, checks you got hints for, etc.)
	- This is useful in **Rupee Mode** ([see below](https://github.com/AudioPixie/TPRTracker?tab=readme-ov-file#fanadis-palace-and-rupee-mode)) to mark junk items that you don't obtain (e.g. seeing a blue rupee that you don't want to waste time grabbing) as it visually marks it off but doesn't affect your rupee count

- Automatic Go Mode
	- The Go Mode graphic appears when you have everything needed to defeat Ganondorf
	- Click on it to make it disappear
	- If you click on it and want it back, head to General Settings to re-enable it
	- The crest button in the top left of the map can be used to manually enable go mode at any time

- Check Clearing
	- A dungeon or area (e.g. Kakariko Village) can be cleared (all checks marked as completed) from the pop-out menu on the right side of the check list box
	- This clears hints, regular, poe, and bug checks for the respective dungeon/area
 	- All poes can be cleared in the same menu (overworld or dungeon separately)
	- Unrequired dungeons can be cleared (based off of the currently selected dungeons in your layout)
	- This does not affect rupee count

- Hint Zones Overlay
	- Enabled with the information button in the top right of the map
	- Displays an overlay detailing in-game hint zone regions
	- Note that all areas that appear in the list box (Dungeons, Ordon, Kakariko Village, etc.) are unique zones

- Flexible Layout and Streaming Compatibility
	- All layout options can be found in the visual settings tab
	- Custom background colors for keying (accepts all hex code configurations and HTML color names)
		- `#rgb`
 		- `#rgba`
		- `#rrggbb`
		- `#rrggbbaa`
		- `lightblue`
	- Compatibility with OBS Game Capture transparency (Windows only, enable "Allow Transparency" in OBS Game Capture and set background color to `#0000`)
	- Items and dungeon keys can be set between transparent or darkened when not yet obtained (visible with custom background colors)
	- Item background box can be enabled/disabled. When enabled, window can be resized to support an item-only view
	- Custom Layout Save

## Spoiler Log integration

You can import your spoiler log .json file directly into the tracker to import settings and utilize the hint system. To import a spoiler log, put it in the ```SpoilerLog``` folder found in the following locations:

Windows: ```.\Pixie's TPR Tracker\Pixie's TPR Tracker_Data\SpoilerLog```  
Mac: ```.\Pixie's TPR Tracker\Content\SpoilerLog```
  
> Note: To find the folder on Mac, right click the app icon and select "Show Package Contents"
  
The SpoilerLog folder is created the first time you run the app, so if you update and can't see it, make sure you run the app first. If you're having issues with the folder creation, you can create the folder manually as long as it's titled **SpoilerLog** and is in the correct file path.

### Import settings

- Autofill settings: automatically populates settings in the General and Seed tabs.
- Generate Item Layout: automatically generates an item layout based on your settings.
- Autofill Required Dungeons: automatically sets your required dungeons in the item layout.
- Autofill Starting Items: automatically marks your starting inventory items.
- Remove Barren Checks: automatically marks excluded checks as completed. Clears unrequired dungeons/post dungeon checks if "Autofill Required Dungeons" is checked and unrequired dungeons are barren. This does not affect rupee count.
- Reset Tracker on Import: Resets the tracker before importing. This does not include a settings reset.

### Saving and deleting your spoiler log

Your spoiler log and generated hints are saved along with everything else in your save file. Deleting or moving the original .json file will not affect the tracker as an internal copy of your spoiler log is made on import. Click "Dump Spoiler Log" to delete this internal copy along with your hints and go back to the import screen.

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

Alternatively, if unrequired dungeons are **not** barren, you could be looking for a key for an unrequired dungeon as only required keys are in the hint pool.

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

## Automatic Race Settings

There are built-in options for races so players without spoiler logs don't have to manually input their settings.

### One-click* Race Settings

Click **Apply Race Settings** in the General Settings Tab to reset the tracker and apply race settings. This will:

- Fully reset the tracker
- Apply all settings in the Seed Settings tab.
- Mark off all checks in the excluded checks list of the settings string. This does not include barren dungeons, once required dungeons are selected use "Clear Unrequired Dungeons" in the pop-out menu on the right side of the check list box.
- Mark off all post-dungeon checks (notably Ilia Memory Quest/Hidden Village checks that are not on the excluded checks list)
- Give the player all items found in the starting items list of the settings string. Also includes Gate Keys and Bulblin Camp Key.
- Turn off Poe checks, Bug checks, and Howling Stones visibility
- Apply the race item layout preset. This will set your 3 dungeons to Forest Temple, Goron Mines, and Lakebed Temple. Dungeons can be changed by right-clicking them.
- Turn off item name tooltips

### Race item layout preset

Click **Race** under Preset Layouts in the Visual Settings tab. This layout is designed as a somewhat compact option to remove items that are unnecessary for race tracking. You will still need to set your required dungeons manually.

### Current race ruleset

**The current race settings are based off of the [Season 1 Tournament ruleset](https://docs.google.com/document/d/13IgxOZ_TnBN73RjJvDCzAemOYV2K9HRfY6dHwJPTk_I/edit?usp=sharing) as of: October 29th, 2024.** 
- Settings String:
	- ```5sQ3g2kPC_-CfeJ8HaX7cJny-NoYqQZKQc7IwNIwNIwN0u70u70u70u70u70u70u71_qwFLTZK61gbCq2Z80-pphmuHTHbBB1BaDknYf_AxydhLmPgSZZbUoyNT5KTnKnI8b6WSbx66LYROE-5GjUYcccP9CNGx20M_b6WAXskPHcrbw8PUjs-vEAKmKvfKLWdIa4eJUDhKdJMGx1QMhM69tq6YE6yvHGff3dsMtKCbWX_m```

Feel free to reach out to me concerning rule changes for race settings so I can update the pack-in spoiler log.

## Current goals and community contribution

Feedback, testing, ideas, and development contributions are extremely welcome and are more than appreciated! Feel free to hit me up in the [TPR Discord](https://discord.gg/tprandomizer) if you want to chat about the tracker. Feel free to take a look at the [issues page](https://github.com/AudioPixie/TPRTracker/issues) for current bugs, future ideas, and what is currently being worked on. As of now these are the mains things I'm focusing on:

- Keeping up-to-date with randomizer releases
- Autotracking
- Bug fixes for critical issues

Thanks for reading this far and happy tracking!

> Fun fact: this project does not contain a single ```Update()``` method
