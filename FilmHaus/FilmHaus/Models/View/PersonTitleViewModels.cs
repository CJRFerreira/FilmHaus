/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
namespace FilmHaus.Models.View
{
    public class PersonTitleViewModel
    {
        public PersonTitleViewModel()
        {
        }

        public PersonViewModel Person { get; set; }

        public TitleViewModel Title { get; set; }
    }
}