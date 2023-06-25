namespace TicTacToe
{
    public class HardAI : AdvancedAI
    {
        public HardAI(Sign sign)
        {
            Sign = sign;
            MaxDepth = 10;
        }
    }
}