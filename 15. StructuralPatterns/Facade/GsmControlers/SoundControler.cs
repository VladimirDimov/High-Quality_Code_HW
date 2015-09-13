namespace Facade.GsmControlers
{
    public enum SoundLevel
    {
        SILENT, LOW, NORMAL, HIGH, VERY_HIGH
    }

    class SoundControler
    {
        public SoundLevel SoundLevel { get; private set; }

        public void SetSoundLevel(SoundLevel level)
        {
            this.SoundLevel = level;
        }

        public override string ToString()
        {
            return "The sound level is set to " + this.SoundLevel.ToString().ToLower() + ".";
        }
    }
}
