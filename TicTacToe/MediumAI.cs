namespace TicTacToe
{
    public class MediumAI : AdvancedAI
    {
        public MediumAI(Sign sign)
        {
            Sign = sign;
            MaxDepth = 3;
        }
    }
}