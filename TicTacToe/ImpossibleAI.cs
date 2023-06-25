namespace TicTacToe
{
    public class ImpossibleAI : AdvancedAI
    {
        public ImpossibleAI(Sign sign)
        {
            Sign = sign;
            MaxDepth = -1;
        }
    }
}