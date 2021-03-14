# Visual Novel Creation Tool
 
This plugin’s purpose is to help developers create a Visual Novel using the Unity Engine. The plugin consists of three editor windows, a database/scriptable object, and a template scene.

## Editor Windows
The Main Editor Window of this plugin is the “Scene Editor” which is accessible from the “Window” menu. There is an option called “Scene Editor”.


## Scene Editor
The scene editor will automatically list all the scenes in the project, as long as they are located in the resources folder. For each scene in the scene editor, three components are generated: the background image field, the Edit Screenplay button, and the Edit Branch button.
The background image field will let you to assign any sprite in the game as the background of the scene. The Edit Screenplay button will bring up a new window of the Screenplay Editor that references the Screenplay in the current scene. The Edit Branch button will bring up a new window of the Branch Editor that references the Branches object in the scene.
The Build button at the very bottom of the Scene Editor will open each listed scene, apply the set backgrounds in the editor to the actual background of each scene, and then save the scene.

### Screenplay Editor
The Screenplay Editor has three main components. The Database field, the Dialogue fields, and the optional Choices fields.
The Database field is where you decide which Character Database do you want to use for this dialogue, leaving it to NONE will break the system. To learn how to create a Character Database please jump ahead to the Character Database section.
The Dialogue fields allow you to manage the Lines. Each line has: a character name field, an emotion enum field, and a dialogue text field. The name field must be written exactly the same as any of the character names created in the Character Database. The emotion enum field has 5 choices, each of them corresponds to different sprites assigned to each character in the Character Database. The last one is the dialogue text field, which will be displayed in the game as the character’s speech.
The Choices fields will appear if the Has Choices toggle box is ticked. The Choices fields contains of Two Choices. Each choice has a choice text (which will be displayed in the game as the choices), a tag (which will be given to the player to keep track that he has made this choice), and sub-dialogue field, which is used to continue the dialogue after the player has chosen a choice.

### Branch Editor
The Branch Editor is used to determine which scene will the player go to based on the Tags they have. The branch Editor allows the user to add multiple branche. For each branch, there are the Next Scene text field and the Tags text field. Each branch only allows for one Next Scene text field but for multiple Tags fields. These Tags will be compared to the Player owned Tags at the end of a Scene, to check which Next Scene the Player will go to.
Important note: The player is persistent, so the player’s Tags will persist over all the scenes. HOWEVER, the player’s Tags are cleared every time the Scene with Build Index 0 is loaded.


## Character Database
The Character Database exists to keep track of Characters and their respective Sprites for their respective emotions. To create a database, users can simply right click in any of the Unity Asset explorer, and create a Character Database. It is important to assign this Database to each Screenplay.

## Template Scene
There is an available Template Scene that can be duplicated and rename to generate more Scenes.
Important: Please don’t create Prefabs out of Game Objects in the scenes. Unity has a bug in which if the script “GameObject.Find” is used to find a Prefab instance, it will get to the Prefab Root and modify that instead. This will break the system as the Prefab Root changes will be applied to all the Scenes.
