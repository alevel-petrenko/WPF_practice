namespace ItemList
{
    /// <summary>
    /// Class represents a template for Phone
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    public sealed class Phone
    {
        /// <summary>
        /// Gets or sets the manufacture of the phone.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        /// The manufacture of the phone.
        /// </value>
        public string Manufacture { get; set; }

        /// <summary>
        /// Gets or sets the model of the phone.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        /// The model of the phone.
        /// </value>
        public string Model { get; set; }
    }
}