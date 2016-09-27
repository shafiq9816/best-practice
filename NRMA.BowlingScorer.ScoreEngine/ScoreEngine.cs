using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NRMA.BowlingScorer.Common;
using System.Collections;

namespace NRMA.BowlingScorer.Core
{
    public class ScoreEngine
    {        
        const int Max_Frame_Size = 11;
        Frame[] frames = new Frame[Max_Frame_Size];
        
        private Frame[] GetFrames(string inputString)
        {
            var inputs = inputString.Trim().Split(' ').Select(x=>int.Parse(x)).ToArray();
            int i =0;
            Frame frame;
            for (var index=0; index< inputs.Length; index++)
            {
                if(inputs[index] == 10 && i < 10){ // if strike and not 10th strike bonus roll
                    frame = new Frame();
                    frame.FirstRoll = 10;
                    frame.SecondRoll = 0; 
                    frames[i] = frame;
                    i++;
                }
                else {
                    frame = new Frame();
                    frame.FirstRoll = inputs[index];
                    if (index < inputs.Length-1)  // incomplete last frame input; without 2nd roll
                    {
                        frame.SecondRoll = inputs[index + 1];
                    }
                    frames[i] = frame;
                    ++index;
                    i++;
                }
            }
            return frames;
        }
        
        public int Score(string input)
        {
            frames = GetFrames(input).Where(x=>x!=null).ToArray();

            var score = 0;
            for (var i=0; i<frames.Length; i++)
            {
                if (frames[i].IsStrike )
                {
                    if (Get2ndNextFrame(i) != null)    // 2nd next frame exist
                    {
                        score += 10 + (GetNextFrame(i).IsStrike ? 10 + Get2ndNextFrame(i).FirstRoll : GetNextFrame(i).FirstRoll + GetNextFrame(i).SecondRoll);
                    }
                    else if (GetNextFrame(i) != null)
                    {
                        score += 10 + GetNextFrame(i).FirstRoll + GetNextFrame(i).SecondRoll;
                    }
                    frames[i].Score = score;
                }
                else if (frames[i].IsSpare && GetNextFrame(i)!=null)
                {
                    score += 10 + (GetNextFrame(i).IsStrike ? 10 : + GetNextFrame(i).FirstRoll);
                }
                else if(i<10)   //11th frame is for bonus. Avoid to calculate score for bonus frame; It's score already considered.
                {
                    score+= frames[i].FirstRoll + frames[i].SecondRoll;
                }
                frames[i].Score = score;    //each frame gets cumulative score
            }
            return score;
        }

        private Frame GetNextFrame(int index)
        {
            if(frames.Length>index+1){
                return frames[index+1];
            }
            return null;
        }

        private Frame Get2ndNextFrame(int index)
        {
            if (frames.Length > index+2)
            {
                return frames[index+2];
            }
            return null;
        }

        public ScoreEngine()
        {
        }

    }
}
