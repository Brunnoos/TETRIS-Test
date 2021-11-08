# TETRIS Test

## How to Play

This games is an adaptation of the [TETRIS Guidelines](https://www.dropbox.com/s/g55gwls0h2muqzn/tetris%20guideline%20docs%202009.zip?dl=0). It can be downloaded through [Google Drive](https://drive.google.com/drive/folders/1mhr5PyPUhM4l9fEJpCokMjbwBeFksSLh?usp=sharing) (Windows Version) or built using Unity 2020.3.22f1.

### Start Menu

You can interact with this screen using your mouse to click on the buttons New Game (starts Game Flow), Exit (closes the game) or, when a Game Flow is active, Continue (to resume Game Flow).

You can also interact with the buttons by using W/S or Arrow Up/Down keyboard keys to highlight a button and Enter to confirm it.

### Game Flow

Following the guideline, during a Game Flow, you can only control the falling Tetrimino. The commands are:

- *A/Arrow Left* and *D/Arrow Right* keys to move left and right, respectively
- *W/Arrow Up* to rotate clockwise
- *S/Arrow Down* to Soft Drop
- *Space Bar* to Hard Drop
- *P* key to Pause

Every time a line in the Playfield Grid (10x20) is fully occupied, all Minos (blocks) inside it are deleted and the **Game Score** is increased by 100. All Minos above fall afterwards.

### Game Over

The Game Over state happens when:

- A Mino is detected at a line above the Grid Limits
- A Tetrimino can't be placed at its spawn point

This ends the current Game Flow, allowing the player to go back to Start Menu to initiate a new game.

## References

This project uses 3D Assets, Audio Clips and Sprites from third party sources, as listed below:

- 3D Model: *Gamecube Logo (Cube)* from [Clara.io](https://clara.io/view/d4b1d5b8-a884-4805-a7a5-3f6f7b8f84fc#) 
- Audio Clips: *Minimal UI Sounds* from [Unity Asset Store](https://assetstore.unity.com/packages/audio/sound-fx/minimal-ui-sounds-78266)
- Sprite: *Keyboard Keys* from [Clker.com](http://www.clker.com/clipart-keyboard-keys-no-alphabets.html)





