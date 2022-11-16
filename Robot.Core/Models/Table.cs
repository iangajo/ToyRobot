using Robot.Core.Interfaces;

namespace Robot.Core.Models
{
    /// <summary>
    /// Table where robot will move
    /// </summary>
    public class Table : ITable
    {
        /// <summary>
        /// Set table dimension
        /// </summary>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public TableTop Set(int length, int width)
        {
            return new TableTop(length, width);
        }
    }
}
