using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;

namespace Yahtzee_Application
{

    public partial class Form1 : Form
    {

        //The amount a player should receive as a bonus
        const int BONUS_SCORE_AMOUNT = 35;

        //The required numbered score to receive the bonus
        const int BONUS_THRESHOLD = 63;

        //The images to display for each die value
        Image[] diceImages;

        //The picture boxes associated with each die
        PictureBox[] dicePictureBoxes;


        //The player's scores for each category
        List<Score> scores;

        //Whether the bonus score was achieved
        bool bonusScore;

        //The dice
        List<Die> dice;

        //The rounds counter
        RoundsCounter roundsCounter;

        //The rolls counter
        RollCounter rollsCounter;

        public Form1()
        {
            InitializeComponent();

            //Pre-initialization
            

            diceImages = new System.Drawing.Image[6] { Properties.Resources.dice1, Properties.Resources.dice2, Properties.Resources.dice3, Properties.Resources.dice4, Properties.Resources.dice5, Properties.Resources.dice6, };
            dicePictureBoxes = new PictureBox[5] { dicePictureBox1, dicePictureBox2, dicePictureBox3, dicePictureBox4, dicePictureBox5};

            //Game initialization
            initializeGame();
        }

        //Game methods

        private void initializeGame()
        {

            //Initialize scores
            Score onesScore = new Score(new OnesScorecardOption());
            Score twosScore = new Score(new TwosScorecardOption());
            Score threesScore = new Score(new ThreesScorecardOption());
            Score foursScore = new Score(new FoursScorecardOption());
            Score fivesScore = new Score(new FivesScorecardOption());
            Score sixesScore = new Score(new SixesScorecardOption());

            Score threeOfAKindScore = new Score(new ThreeOfAKindScorecardOption());
            Score fourOfAKindScore = new Score(new FourOfAKindScorecardOption());
            Score fullHouseScore = new Score(new FullHouseScorecardOption());
            Score smallStraightScore = new Score(new SmallStraightScorecardOption());
            Score largeStraightScore = new Score(new LargeStraightScorecardOption());
            Score chanceScore = new Score(new ChanceScorecardOption());
            Score yahtzeeScore = new Score(new YahtzeeScorecardOption());

            //Add scores to index
            scores = new List<Score>();

            scores.Add(onesScore);
            scores.Add(twosScore);
            scores.Add(threesScore);
            scores.Add(foursScore);
            scores.Add(fivesScore);
            scores.Add(sixesScore);

            scores.Add(threeOfAKindScore);
            scores.Add(fourOfAKindScore);
            scores.Add(fullHouseScore);
            scores.Add(smallStraightScore);
            scores.Add(largeStraightScore);
            scores.Add(chanceScore);
            scores.Add(yahtzeeScore);

            //Initialize to no bonus
            bonusScore = false;

            //Initialize the dice
            dice = new List<Die>();

            //Initialize the random number generator
            Random random = new Random();

            for (int index = 0; index < 5; index++)
            {

                //Create a new die
                Die die = new Die(new RandomWrapper(random));

                //Add to the index
                dice.Add(die);
            }

            //Create the counters
            roundsCounter = new RoundsCounter();
            rollsCounter = new RollCounter();
        }

        private void recalculateScores()
        {

            //The dice values
            int[] diceValues = new int[5];

            //For each die
            for (int index = 0; index < dice.Count; index++)
            {
                //Set the dice value in the array
                diceValues[index] = dice[index].getValue();
            }

            //For each score
            for (int index = 0; index < scores.Count; index++)
            {

                //Recalculate the current score
                scores[index].calculateScore(diceValues);
            }
        }

        private void initializeRound()
        {

            //Reset the rolls counter
            rollsCounter.reset();

            //For each die
            for (int index = 0; index < 5; index++)
            {

                //Reset the dice
                dice[index].reset();
            }

            //Reset the dice checkboxes
            holdCheckBox1.CheckState = CheckState.Unchecked;
            holdCheckBox2.CheckState = CheckState.Unchecked;
            holdCheckBox3.CheckState = CheckState.Unchecked;
            holdCheckBox4.CheckState = CheckState.Unchecked;
            holdCheckBox5.CheckState = CheckState.Unchecked;

            //Update the scoreboard
            updateScoreboard();
        }

        private void updateScoreboard()
        {

            //Set the visible score
            onesLabel2.Text = scores[0].getScore().ToString();

            //Set color
            if (scores[0].isLocked() == false)
            {

                //Red if unchosen
                onesLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);

                //If score is 0
                if (scores[0].getScore() == 0)
                {

                    //Don't display text
                    onesLabel2.Text = string.Empty;
                }
            }
            else
            {
                
                //Black if chosen
                onesLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
            }

            //Set the visible score
            twosLabel2.Text = scores[1].getScore().ToString();

            //Set color
            if (scores[1].isLocked() == false)
            {

                //Red if unchosen
                twosLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);

                //If score is 0
                if (scores[1].getScore() == 0)
                {

                    //Don't display text
                    twosLabel2.Text = string.Empty;
                }
            }
            else
            {

                //Black if chosen
                twosLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
            }

            //Set the visible score
            threesLabel2.Text = scores[2].getScore().ToString();

            //Set color
            if (scores[2].isLocked() == false)
            {

                //Red if unchosen
                threesLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);

                //If score is 0
                if (scores[2].getScore() == 0)
                {

                    //Don't display text
                    threesLabel2.Text = string.Empty;
                }
            }
            else
            {

                //Black if chosen
                threesLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
            }

            //Set the visible score
            foursLabel2.Text = scores[3].getScore().ToString();

            //Set color
            if (scores[3].isLocked() == false)
            {

                //Red if unchosen
                foursLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);

                //If score is 0
                if (scores[3].getScore() == 0)
                {

                    //Don't display text
                    foursLabel2.Text = string.Empty;
                }
            }
            else
            {

                //Black if chosen
                foursLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
            }

            //Set the visible score
            fivesLabel2.Text = scores[4].getScore().ToString();

            //Set color
            if (scores[4].isLocked() == false)
            {

                //Red if unchosen
                fivesLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);

                //If score is 0
                if (scores[4].getScore() == 0)
                {

                    //Don't display text
                    fivesLabel2.Text = string.Empty;
                }
            }
            else
            {

                //Black if chosen
                fivesLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
            }

            //Set the visible score
            sixesLabel2.Text = scores[5].getScore().ToString();

            //Set color
            if (scores[5].isLocked() == false)
            {

                //Red if unchosen
                sixesLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);

                //If score is 0
                if (scores[5].getScore() == 0)
                {

                    //Don't display text
                    sixesLabel2.Text = string.Empty;
                }
            }
            else
            {

                //Black if chosen
                sixesLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
            }

            //Set the visible score
            threeOfAKindLabel2.Text = scores[6].getScore().ToString();

            //Set color
            if (scores[6].isLocked() == false)
            {

                //Red if unchosen
                threeOfAKindLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);

                //If score is 0
                if (scores[6].getScore() == 0)
                {

                    //Don't display text
                    threeOfAKindLabel2.Text = string.Empty;
                }
            }
            else
            {

                //Black if chosen
                threeOfAKindLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
            }

            //Set the visible score
            fourOfAKindLabel2.Text = scores[7].getScore().ToString();

            //Set color
            if (scores[7].isLocked() == false)
            {

                //Red if unchosen
                fourOfAKindLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);

                //If score is 0
                if (scores[7].getScore() == 0)
                {

                    //Don't display text
                    fourOfAKindLabel2.Text = string.Empty;
                }
            }
            else
            {

                //Black if chosen
                fourOfAKindLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
            }

            //Set the visible score
            fullHouseLabel2.Text = scores[8].getScore().ToString();

            //Set color
            if (scores[8].isLocked() == false)
            {

                //Red if unchosen
                fullHouseLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);

                //If score is 0
                if (scores[8].getScore() == 0)
                {

                    //Don't display text
                    fullHouseLabel2.Text = string.Empty;
                }
            }
            else
            {

                //Black if chosen
                fullHouseLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
            }

            //Set the visible score
            smallStraightLabel2.Text = scores[9].getScore().ToString();

            //Set color
            if (scores[9].isLocked() == false)
            {

                //Red if unchosen
                smallStraightLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);

                //If score is 0
                if (scores[9].getScore() == 0)
                {

                    //Don't display text
                    smallStraightLabel2.Text = string.Empty;
                }
            }
            else
            {

                //Black if chosen
                smallStraightLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
            }

            //Set the visible score
            largeStraightLabel2.Text = scores[10].getScore().ToString();

            //Set color
            if (scores[10].isLocked() == false)
            {

                //Red if unchosen
                largeStraightLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);

                //If score is 0
                if (scores[10].getScore() == 0)
                {

                    //Don't display text
                    largeStraightLabel2.Text = string.Empty;
                }
            }
            else
            {

                //Black if chosen
                largeStraightLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
            }

            //Set the visible score
            chanceLabel2.Text = scores[11].getScore().ToString();

            //Set color
            if (scores[11].isLocked() == false)
            {

                //Red if unchosen
                chanceLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);

                //If score is 0
                if (scores[11].getScore() == 0)
                {

                    //Don't display text
                    chanceLabel2.Text = string.Empty;
                }
            }
            else
            {

                //Black if chosen
                chanceLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
            }

            //Set the visible score
            yahtzeeLabel2.Text = scores[12].getScore().ToString();

            //Set color
            if (scores[12].isLocked() == false)
            {

                //Red if unchosen
                yahtzeeLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);

                //If score is 0
                if (scores[12].getScore() == 0)
                {

                    //Don't display text
                    yahtzeeLabel2.Text = string.Empty;
                }
            }
            else
            {

                //Black if chosen
                yahtzeeLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
            }
        }

        private void updateDiceDisplays()
        {

            //The value of each die
            int value;

            //For each die
            for (int index = 0; index < dicePictureBoxes.Count(); index++)
            {

                //Get dice value
                value = dice[index].getValue();

                //If value is valid
                if (value > 0 && value <= 6)
                {

                    //Apply image
                    dicePictureBoxes[index].Image = diceImages[value - 1];
                }
            }
        }

        private void roll()
        {

            //For each die
            for (int index = 0; index < dice.Count; index++)
            {

                //Roll the die
                dice[index].roll();
            }

            //Updates the score values
            recalculateScores();

            //Increment the roll counter
            rollsCounter.increment();

            //Update the dice displays
            updateDiceDisplays();

            //Update the scoreboard
            updateScoreboard();
        }

        private void nextRound()
        {

            //Increment the rounds counter
            roundsCounter.increment();

            //If the game isn't finished
            if (roundsCounter.gameFinished() == false)
            {

                //Initialize the next round
                initializeRound();
            }
            else
            {

                //End the game
                endGame();
            }
        }

        private void checkBonus()
        {

            //The sum of the numbered scores
            int numberedTotal = 0;

            //For each of the numbered score options
            for (int index = 0; index < 6; index++)
            {

                //Get the current score option
                Score score = scores[index];

                //If the current score option is locked
                if (score.isLocked())
                {

                    //Add to the total
                    numberedTotal += score.getScore();
                }

            }

            //If the bonus was achieved
            if (numberedTotal >= BONUS_THRESHOLD)
            {

                //Mark bonus as achieved
                bonusScore = true;

                //Update bonus label
                bonusLabel2.Text = BONUS_SCORE_AMOUNT.ToString();
            }
        }

        private void endGame()
        {

            //Update the scoreboard
            updateScoreboard();

            //The final score
            int finalScore = 0;

            //For each score
            for (int index = 0; index < scores.Count(); index++)
            {

                //Add the individual score to the final score
                finalScore += scores[index].getScore();
            }

            //If the bonus was received
            if (bonusScore)
            {

                //Add the bonus score
                finalScore += BONUS_SCORE_AMOUNT;
            }

            //Display the final score
            finalScoreLabel2.Text = finalScore.ToString();

            //Display the "game finished" label
            gameFinishedLabel.Visible = true;
        }

        //Score choice buttons

        private void attemptChooseScore(SCORE_ID identifier)
        {

            //The score instance associated with this button
            Score score = scores[(int)identifier];

            //If the user can choose this score
            if (rollsCounter.hasRolled() && score.isLocked() == false)
            {
                
                //Lock in the current score
                score.lockScore();

                //Check whether the bonus score was achieved
                checkBonus();

                //Go to the next round
                nextRound();
            }
        }

        private void onesButton_Click(object sender, EventArgs e)
        {

            //Attempt to choose this score
            attemptChooseScore(SCORE_ID.ONES);
        }

        private void twosButton_Click(object sender, EventArgs e)
        {

            //Attempt to choose this score
            attemptChooseScore(SCORE_ID.TWOS);
        }

        private void threesButton_Click(object sender, EventArgs e)
        {

            //Attempt to choose this score
            attemptChooseScore(SCORE_ID.THREES);
        }

        private void foursButton_Click(object sender, EventArgs e)
        {

            //Attempt to choose this score
            attemptChooseScore(SCORE_ID.FOURS);
        }

        private void fivesButton_Click(object sender, EventArgs e)
        {

            //Attempt to choose this score
            attemptChooseScore(SCORE_ID.FIVES);
        }

        private void sixesButton_Click(object sender, EventArgs e)
        {

            //Attempt to choose this score
            attemptChooseScore(SCORE_ID.SIXES);
        }

        private void threeOfAKindButton_Click(object sender, EventArgs e)
        {

            //Attempt to choose this score
            attemptChooseScore(SCORE_ID.THREE_OF_A_KIND);
        }

        private void fourOfAKindButton_Click(object sender, EventArgs e)
        {

            //Attempt to choose this score
            attemptChooseScore(SCORE_ID.FOUR_OF_A_KIND);
        }

        private void fullHouseButton_Click(object sender, EventArgs e)
        {

            //Attempt to choose this score
            attemptChooseScore(SCORE_ID.FULL_HOUSE);
        }

        private void smallStraightButton_Click(object sender, EventArgs e)
        {

            //Attempt to choose this score
            attemptChooseScore(SCORE_ID.SMALL_STRAIGHT);
        }

        private void largeStraightButton_Click(object sender, EventArgs e)
        {

            //Attempt to choose this score
            attemptChooseScore(SCORE_ID.LARGE_STRAIGHT);
        }

        private void chanceButton_Click(object sender, EventArgs e)
        {

            //Attempt to choose this score
            attemptChooseScore(SCORE_ID.CHANCE);
        }

        private void yahtzeeButton_Click(object sender, EventArgs e)
        {

            //Attempt to choose this score
            attemptChooseScore(SCORE_ID.YAHTZEE);
        }

        //Hold buttons

        private void changeDieHeld(object sender, int position)
        {
            
            //Get the sending checkbox
            CheckBox checkBox = sender as CheckBox;

            //Get the state of the checkbox
            bool isChecked = false;

            //If the box is checked
            if (checkBox.CheckState == CheckState.Checked)
            {

                //Mark as checked
                isChecked = true;
            }

            //If the dice have been rolled
            if (rollsCounter.hasRolled())
            {

                //Mark the associated die as held
                dice[position].setHold(isChecked);
            } else
            {

                //Reset the checkbox
                checkBox.CheckState = CheckState.Unchecked;
            }
        }

        private void holdCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            //Change the associated die's held state
            changeDieHeld(sender, 0);
        }

        private void holdCheckBox2_CheckedChanged(object sender, EventArgs e)
        {

            //Change the associated die's held state
            changeDieHeld(sender, 1);
        }

        private void holdCheckBox3_CheckedChanged(object sender, EventArgs e)
        {

            //Change the associated die's held state
            changeDieHeld(sender, 2);
        }

        private void holdCheckBox4_CheckedChanged(object sender, EventArgs e)
        {

            //Change the associated die's held state
            changeDieHeld(sender, 3);
        }

        private void holdCheckBox5_CheckedChanged(object sender, EventArgs e)
        {

            //Change the associated die's held state
            changeDieHeld(sender, 4);
        }

        //Roll button

        private void attemptRoll()
        {

            //If the user can roll
            if (rollsCounter.canRoll())
            {

                //Roll the dice
                roll();
            }
        }

        private void rollButton_Click(object sender, EventArgs e)
        {

            //Attempt to roll the die
            attemptRoll();
        }
    }

    //Score types enumerator
    public enum SCORE_ID
    {
        ONES = 0,
        TWOS = 1,
        THREES = 2,
        FOURS = 3,
        FIVES = 4,
        SIXES = 5,
        THREE_OF_A_KIND = 6,
        FOUR_OF_A_KIND = 7,
        FULL_HOUSE = 8,
        SMALL_STRAIGHT = 9,
        LARGE_STRAIGHT = 10,
        CHANCE = 11,
        YAHTZEE = 12
    };
    
    //Random number generator interface
    public interface IRandom
    {

        //Get the next random number within a given range
        int Next(int minInclusive, int maxExclusive);
    }

    //Random wrapper
    public class RandomWrapper : IRandom
    {

        //The random number generator
        Random random;

        //Constructor
        public RandomWrapper(Random random)
        {

            //Set member
            this.random = random;
        }

        //Returns a legitimate psuedorandom number
        public int Next(int minimum, int maximum)
        {
            //Return the result of the random class
            return random.Next(minimum, maximum);
        }
    }

    //Fake random number generator
    public class FakeRandom : IRandom
    {

        //The number that this fake random number generator is set to return
        int value;

        //Constructor
        public FakeRandom(int value)
        {

            //Set member
            this.value = value;
        }

        //Returns the set number
        public int Next(int minimum, int maximum)
        {

            //Return the set value
            return value;
        }
    }

    //A die
    public class Die
    {

        //The die's random number generator
        IRandom random;

        //The current value of the die
        int value;

        //Whether the die is held
        bool held;

        //Constructor
        public Die(IRandom random)
        {

            //Initialize members
            this.random = random;
            value = 0;
            held = false;
        }

        //Rolls the die
        public void roll()
        {

            //If die is not held
            if (held == false)
            {

                //Generate a new random value
                value = random.Next(1, 7);
            }

        }

        //Resets the die's values
        public void reset()
        {

            //Mark as not held
            held = false;

            //Reset value
            value = 0;
        }

        //Returns the value of the die
        public int getValue()
        {

            //Return the value
            return value;
        }

        //Sets the die's "held" status
        public void setHold(bool state)
        {

            //Set held status
            held = state;
        }
    }

    //A score object
    public class Score
    {

        //The score calculator
        IScorecardOption calculator;

        //The score value
        int score;

        //Whether the score is locked
        bool locked;

        //Constructor
        public Score(IScorecardOption scoreCalculator)
        {

            //Initialize members
            calculator = scoreCalculator;
            score = 0;
            locked = false;
        }

        //Recalculates the stored score value with the given dice if not locked
        public void calculateScore(int[] dice)
        {
            
            //If not locked
            if (locked == false)
            {

                //Recalculate the stored score
                score = calculator.getScore(dice);
            }
        }

        //Returns the current score
        public int getScore()
        {

            //Return the current score
            return score;
        }

        //Locks the current score
        public void lockScore()
        {

            //Mark as locked
            locked = true;
        }

        //Returns whether this score is locked
        public bool isLocked()
        {

            //Return the locked state
            return locked;
        }
    }
    
    //The roll counter
    public class RollCounter
    {

        //The current roll count
        int count;

        //Constructor
        public RollCounter()
        {

            //Initialize variable
            count = 0;
        }

        //Increments the counter
        public void increment()
        {

            //Increment
            count++;
        }

        //Tests whether the user can roll again
        public bool canRoll()
        {

            //The result
            bool result = false;

            //Return whether the user can roll again
            if (count < 3)
            {

                result = true;
            }

            //Return the result
            return result;
        }

        //Tests whether the user has rolled at least once
        public bool hasRolled()
        {

            //The result
            bool result = false;

            //Return whether the user has rolled
            if (count > 0)
            {

                result = true;
            }

            //Return the result
            return result;
        }

        //Resets the counter
        public void reset()
        {

            //Re-initialize variable
            count = 0;
        }
    }

    //The rounds counter
    public class RoundsCounter
    {

        //The current round
        int round;

        //Constructor
        public RoundsCounter()
        {

            //Initialize rounds to zero
            round = 0;
        }

        //Increments the counter
        public void increment()
        {

            //Increment rounds counter
            round++;
        }

        //Returns whether the game is finished
        public bool gameFinished()
        {

            //The result
            bool result = false;

            //If game finished
            if (round >= 13)
            {

                //Set result
                result = true;
            }

            //Return the result
            return result;
        }

        //Resets the counter
        public void reset()
        {

            //Reset counter
            round = 0;
        }
    }

    //Interface implemented by score calculators
    public interface IScorecardOption
    {

        //Returns the score resulting from the given dice values
        int getScore(int[] dice);
    }

    //The scorecard option calculators
    public class OnesScorecardOption : IScorecardOption
    {

        //Calculate the player's score from the dice values
        public int getScore(int[] dice)
        {

            //Exit if any dice have invalid values
            for (int index = 0; index < 5; index++)
            {

                if (dice[index] <= 0 || dice[index] > 6)
                {
                    return 0;
                }
            }

            //The player's score if this is chosen
            int score = 0;

            //For each die
            for (int index = 0; index < 5; index++)
            {

                //If the die's value is 1
                if (dice[index] == 1)
                {

                    //Increment the score counter
                    score += 1;
                }
            }

            //Return the score
            return score;
        }

    }

    public class TwosScorecardOption : IScorecardOption
    {

        //Calculate the player's score from the dice values
        public int getScore(int[] dice)
        {

            //Exit if any dice have invalid values
            for (int index = 0; index < 5; index++)
            {

                if (dice[index] <= 0 || dice[index] > 6)
                {
                    return 0;
                }
            }

            //The player's score if this is chosen
            int score = 0;

            //For each die
            for (int index = 0; index < 5; index++)
            {

                //If the die's value is 2
                if (dice[index] == 2)
                {

                    //Increment the score counter
                    score += 2;
                }
            }

            //Return the score
            return score;
        }

    }

    public class ThreesScorecardOption : IScorecardOption
    {

        //Calculate the player's score from the dice values
        public int getScore(int[] dice)
        {

            //Exit if any dice have invalid values
            for (int index = 0; index < 5; index++)
            {

                if (dice[index] <= 0 || dice[index] > 6)
                {
                    return 0;
                }
            }

            //The player's score if this is chosen
            int score = 0;

            //For each die
            for (int index = 0; index < 5; index++)
            {

                //If the die's value is 3
                if (dice[index] == 3)
                {

                    //Increment the score counter
                    score += 3;
                }
            }

            //Return the score
            return score;
        }

    }

    public class FoursScorecardOption : IScorecardOption
    {

        //Calculate the player's score from the dice values
        public int getScore(int[] dice)
        {

            //Exit if any dice have invalid values
            for (int index = 0; index < 5; index++)
            {

                if (dice[index] <= 0 || dice[index] > 6)
                {
                    return 0;
                }
            }

            //The player's score if this is chosen
            int score = 0;

            //For each die
            for (int index = 0; index < 5; index++)
            {

                //If the die's value is 4
                if (dice[index] == 4)
                {

                    //Increment the score counter
                    score += 4;
                }
            }

            //Return the score
            return score;
        }

    }

    public class FivesScorecardOption : IScorecardOption
    {

        //Calculate the player's score from the dice values
        public int getScore(int[] dice)
        {

            //Exit if any dice have invalid values
            for (int index = 0; index < 5; index++)
            {

                if (dice[index] <= 0 || dice[index] > 6)
                {
                    return 0;
                }
            }

            //The player's score if this is chosen
            int score = 0;

            //For each die
            for (int index = 0; index < 5; index++)
            {

                //If the die's value is 5
                if (dice[index] == 5)
                {

                    //Increment the score counter
                    score += 5;
                }
            }

            //Return the score
            return score;
        }

    }

    public class SixesScorecardOption : IScorecardOption
    {

        //Calculate the player's score from the dice values
        public int getScore(int[] dice)
        {

            //Exit if any dice have invalid values
            for (int index = 0; index < 5; index++)
            {

                if (dice[index] <= 0 || dice[index] > 6)
                {
                    return 0;
                }
            }

            //The player's score if this is chosen
            int score = 0;

            //For each die
            for (int index = 0; index < 5; index++)
            {

                //If the die's value is 6
                if (dice[index] == 6)
                {

                    //Increment the score counter
                    score += 6;
                }
            }

            //Return the score
            return score;
        }

    }

    public class ThreeOfAKindScorecardOption : IScorecardOption
    {

        //Calculate the player's score from the dice values
        public int getScore(int[] dice)
        {

            //Exit if any dice have invalid values
            for (int index = 0; index < 5; index++)
            {

                if (dice[index] <= 0 || dice[index] > 6)
                {
                    return 0;
                }
            }

            //The player's score if this is chosen
            int score = 0;

            //The sum of the dice
            int sum = 0;

            //Whether the conditions are met for the dice to be three of a kind
            bool threeOfAKind = false;

            //The number of times each die number (1-6) was rolled
            int[] count = new int[] { 0, 0, 0, 0, 0, 0 };

            //The current dice value (used by the loop)
            int value;

            //For each die
            for (int index = 0; index < 5; index++)
            {

                //Get the current value of the dice
                value = dice[index];

                //Increase the count of the die value
                count[value - 1]++;

                //If more than three dice of that value
                if (count[value - 1] >= 3)
                {

                    //Mark as three of a kind
                    threeOfAKind = true;
                }

                //Add to the sum
                sum += value;
            }

            //If conditions are met
            if (threeOfAKind)
            {

                //Set score for three of a kind
                score = sum;
            }

            //Return score
            return score;
        }

    }

    public class FourOfAKindScorecardOption : IScorecardOption
    {

        //Calculate the player's score from the dice values
        public int getScore(int[] dice)
        {

            //Exit if any dice have invalid values
            for (int index = 0; index < 5; index++)
            {

                if (dice[index] <= 0 || dice[index] > 6)
                {
                    return 0;
                }
            }

            //The player's score if this is chosen
            int score = 0;

            //The sum of the dice
            int sum = 0;

            //Whether the conditions are met for the dice to be four of a kind
            bool fourOfAKind = false;

            //The number of times each die number (1-6) was rolled
            int[] count = new int[] { 0, 0, 0, 0, 0, 0 };

            //The current dice value (used by the loop)
            int value;

            //For each die
            for (int index = 0; index < 5; index++)
            {

                //Get the current value of the dice
                value = dice[index];

                //Increase the count of the die value
                count[value - 1]++;

                //If more than four dice of that value
                if (count[value - 1] >= 4)
                {

                    //Mark as four of a kind
                    fourOfAKind = true;
                }

                //Add to the sum
                sum += value;
            }

            //If conditions are met
            if (fourOfAKind)
            {

                //Set score for three of a kind
                score = sum;
            }

            //Return score
            return score;
        }

    }

    public class FullHouseScorecardOption : IScorecardOption
    {

        //Calculate the player's score from the dice values
        public int getScore(int[] dice)
        {

            //Exit if any dice have invalid values
            for (int index = 0; index < 5; index++)
            {

                if (dice[index] <= 0 || dice[index] > 6)
                {
                    return 0;
                }
            }

            //The player's score if this option is chosen
            int score = 0;

            //Whether exactly three dice have the same number
            bool triple = false;

            //Whether exactly two dice have the same number
            bool pair = false;

            //The number of times each die number (1-6) was rolled
            int[] count = new int[] { 0, 0, 0, 0, 0, 0 };

            //The current dice value (used by the for loop)
            int value;

            //For each die
            for (int index = 0; index < 5; index++)
            {

                //Get the die value
                value = dice[index];

                //Increment the counter
                count[value - 1]++;
            }

            //For each number (1-6)
            for (int index = 0; index < 6; index++)
            {

                //If the number of dice with this number is 3
                if (count[index] == 3)
                {

                    //A triple is present
                    triple = true;
                }

                //If the number of dice with this number is 2
                if (count[index] == 2)
                {

                    //A pair is present
                    pair = true;
                }
            }

            //If the full house conditions are met
            if (triple && pair)
            {

                //Set the score
                score = 25;
            }

            //Return the score
            return score;
        }

    }

    public class SmallStraightScorecardOption : IScorecardOption
    {

        //Calculate the player's score from the dice values
        public int getScore(int[] dice)
        {

            //Exit if any dice have invalid values
            for (int index = 0; index < 5; index++)
            {

                if (dice[index] <= 0 || dice[index] > 6)
                {
                    return 0;
                }
            }

            //The players score if this option is chosen
            int score = 0;

            //Whether the dice meet the conditions
            bool isSmallStraight = false;

            //Whether each possible number (1-6) was rolled
            bool[] numbersPresent = new bool[] { false, false, false, false, false, false };

            //The current value of the die (used by the loop)
            int value = 0;

            //For each die
            for (int index = 0; index < 5; index++)
            {

                //Get the current die value
                value = dice[index];

                //Mark the value as rolled
                numbersPresent[value - 1] = true;
            }

            //For each possible small straight
            for (int outerIndex = 0; outerIndex < 3; outerIndex++)
            {

                //Whether the small straight test was failed
                bool testFailed = false;

                //For each number within the test
                for (int innerIndex = 0; innerIndex < 4; innerIndex++)
                {

                    //If the number isn't present
                    if (numbersPresent[outerIndex + innerIndex] == false)
                    {

                        //Fail the test
                        testFailed = true;
                    }

                }

                //If the test wasn't failed for this combination
                if (testFailed == false)
                {

                    //Mark as small straight
                    isSmallStraight = true;
                }
            }

            //If the dice are a small straight
            if (isSmallStraight)
            {

                //Set the score
                score = 30;
            }

            //Return the score
            return score;
        }

    }

    public class LargeStraightScorecardOption : IScorecardOption
    {

        //Calculate the player's score from the dice values
        public int getScore(int[] dice)
        {

            //Exit if any dice have invalid values
            for (int index = 0; index < 5; index++)
            {

                if (dice[index] <= 0 || dice[index] > 6)
                {
                    return 0;
                }
            }

            //The players score if this option is chosen
            int score = 0;

            //Whether the dice meet the conditions
            bool isLargeStraight = false;

            //Whether each possible number (1-6) was rolled
            bool[] numbersPresent = new bool[] { false, false, false, false, false, false };

            //The current value of the die (used by the loop)
            int value = 0;

            //For each die
            for (int index = 0; index < 5; index++)
            {

                //Get the current die value
                value = dice[index];

                //Mark the value as rolled
                numbersPresent[value - 1] = true;
            }

            //For each possible large straight
            for (int outerIndex = 0; outerIndex < 2; outerIndex++)
            {

                //Whether the large straight test was failed
                bool testFailed = false;

                //For each number within the test
                for (int innerIndex = 0; innerIndex < 5; innerIndex++)
                {

                    //If the number isn't present
                    if (numbersPresent[outerIndex + innerIndex] == false)
                    {

                        //Fail the test
                        testFailed = true;
                    }

                }

                //If the test wasn't failed for this combination
                if (testFailed == false)
                {

                    //Mark as small straight
                    isLargeStraight = true;
                }
            }

            //If the dice are a large straight
            if (isLargeStraight)
            {

                //Set the score
                score = 40;
            }

            //Return the score
            return score;
        }

    }

    public class ChanceScorecardOption : IScorecardOption
    {

        //Calculate the player's score from the dice values
        public int getScore(int[] dice)
        {

            //Exit if any dice have invalid values
            for (int index = 0; index < 5; index++)
            {

                if (dice[index] <= 0 || dice[index] > 6)
                {
                    return 0;
                }
            }

            //The players score if this option is chosen
            int score = 0;

            //For each die
            for (int index = 0; index < 5; index++)
            {

                //Add the value of the die
                score += dice[index];
            }

            //Return the score
            return score;
        }

    }

    public class YahtzeeScorecardOption : IScorecardOption
    {

        //Calculate the player's score from the dice values
        public int getScore(int[] dice)
        {

            //Exit if any dice have invalid values
            for (int index = 0; index < 5; index++)
            {

                if (dice[index] <= 0 || dice[index] > 6)
                {
                    return 0;
                }
            }

            //The players score if this option is chosen
            int score = 0;

            //The number of times each die number (1-6) was rolled
            int[] count = new int[] { 0, 0, 0, 0, 0, 0 };

            //Whether the dice are a yahtzee
            bool isYahtzee = false;

            //The current dice value (used by the loop)
            int value;

            //For each die
            for (int index = 0; index < 5; index++)
            {

                //Get the current dice value
                value = dice[index];

                //Add the value to the counters
                count[value - 1]++;

                //If the current counter has reached 5
                if (count[value - 1] == 5)
                {

                    //Mark as a yahtzee
                    isYahtzee = true;
                }
            }

            //If the dice are a yahtzee
            if (isYahtzee)
            {

                //Set the score
                score = 50;
            }

            //Return the score
            return score;
        }

    }
}
