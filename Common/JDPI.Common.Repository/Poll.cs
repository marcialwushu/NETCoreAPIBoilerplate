using DTO;

namespace JDPI.Common.Repository
{
    internal class Poll : Vote
    {
        public object Votes { get; internal set; }
        public object Id { get; internal set; }
    }
}