namespace Services
{
    public class PlayerStartsService
    {
        
        /// <summary>
        /// Current money
        /// </summary>
        public int Money { get; set; }
        
        /// <summary>
        /// Current lives
        /// </summary>
        public int Lives { get; set; }  
        
        /// <summary>
        /// Rounds survived
        /// </summary>
        public int Rounds { get; set; }
        
        /// <summary>
        /// Has paused
        /// </summary>
        public bool HasPaused { get; set; }
        
        /// <summary>
        /// Has game over
        /// </summary>
        public bool HasGameOver { get; set; }
    }
}