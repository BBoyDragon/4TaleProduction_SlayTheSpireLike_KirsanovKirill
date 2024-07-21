namespace Code.Models.CardSystem.CardActionSystem
{
    public interface ICardAction
    {
        public void Execute();
        public bool CanBePlayed();
    }
}