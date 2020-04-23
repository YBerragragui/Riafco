using Riafco.Dal.Dataflex.Pro.Interface;
using Riafco.Entity.Dataflex.Pro.About;
using Riafco.Entity.Dataflex.Pro.Activites;
using Riafco.Entity.Dataflex.Pro.Authorizarion;
using Riafco.Entity.Dataflex.Pro.Contact;
using Riafco.Entity.Dataflex.Pro.Languages;
using Riafco.Entity.Dataflex.Pro.News;
using Riafco.Entity.Dataflex.Pro.Newsletters;
using Riafco.Entity.Dataflex.Pro.Occurrences;
using Riafco.Entity.Dataflex.Pro.Offices;
using Riafco.Entity.Dataflex.Pro.Partners;
using Riafco.Entity.Dataflex.Pro.Ressources;


namespace Riafco.Service.Dataflex.Pro.UnitOfWork
{
    /// <summary>
    /// The unit of work interface.
    /// </summary>
    public interface IUnitOfWork
    {
        #region Authorization

        /// <summary>
        /// the user repository.
        /// </summary>
        IGenericRepository<User> UserRepository { get; }

        /// <summary>
        /// the UserRuleRepository.
        /// </summary>
        IGenericRepository<UserRule> UserRuleRepository { get; }

        /// <summary>
        /// the rule repository
        /// </summary>
        IGenericRepository<Rule> RuleRepository { get; }

        #endregion

        #region Language
        /// <summary>
        /// the language repository.
        /// </summary>
        IGenericRepository<Language> LanguageRepository { get; }
        #endregion

        #region Activites
        /// <summary>
        /// activity repository
        /// </summary>
        IGenericRepository<Activity> ActivityRepository { get; }

        /// <summary>
        /// the activity translation repository
        /// </summary>
        IGenericRepository<ActivityTranslation> ActivityTranslationRepository { get; }

        /// <summary>
        /// The activity paragraphe repository.
        /// </summary>
        IGenericRepository<ActivityParagraph> ActivityParagraphRepository { get; }

        /// <summary>
        /// The activity paragraph traslation.
        /// </summary>
        IGenericRepository<ActivityParagraphTranslation> ActivityParagraphTraslationRepository { get; }

        /// <summary>
        /// The ActivityFileRepository.
        /// </summary>
        IGenericRepository<ActivityFile> ActivityFileRepository { get; }

        /// <summary>
        /// The ActivityFileTranslationRepository.
        /// </summary>
        IGenericRepository<ActivityFileTranslation> ActivityFileTranslationRepository { get; }
        #endregion

        #region News
        /// <summary>
        /// The NewsRepository.
        /// </summary>
        IGenericRepository<Entity.Dataflex.Pro.News.News> NewsRepository { get; }

        /// <summary>
        /// The NewsTranslationRepository.
        /// </summary>
        IGenericRepository<NewsTranslation> NewsTranslationRepository { get; }
        #endregion

        #region Occurrences
        /// <summary>
        /// The OccurrenceRepository
        /// </summary>
        IGenericRepository<Occurrence> OccurrenceRepository { get; }

        /// <summary>
        /// The OccurrenceTranslationRepository
        /// </summary>
        IGenericRepository<OccurrenceTranslation> OccurrenceTranslationRepository { get; }
        #endregion

        #region About
        /// <summary>
        /// The SectionRepository
        /// </summary>
        IGenericRepository<Section> SectionRepository { get; }

        /// <summary>
        /// The SectionTranslationRepository
        /// </summary>
        IGenericRepository<SectionTranslation> SectionTranslationRepository { get; }

        /// <summary>
        /// The section paragraphe repository.
        /// </summary>
        IGenericRepository<SectionParagraph> SectionParagraphRepository { get; }

        /// <summary>
        /// The section paragraph traslation.
        /// </summary>
        IGenericRepository<SectionParagraphTranslation> SectionParagraphTraslationRepository { get; }

        /// <summary>
        /// The SectionFileRepository.
        /// </summary>
        IGenericRepository<SectionFile> SectionFileRepository { get; }

        /// <summary>
        /// The SectionFileTranslationRepository.
        /// </summary>
        IGenericRepository<SectionFileTranslation> SectionFileTranslationRepository { get; }

        /// <summary>
        /// The step repository.
        /// </summary>
        IGenericRepository<Step> StepRepository { get; }

        /// <summary>
        /// step paragraph repository.
        /// </summary>
        IGenericRepository<StepParagraph> StepParagraphRepository { get; }

        /// <summary>
        /// Step paragraph translation repository.
        /// </summary>
        IGenericRepository<StepParagraphTranslation> StepParagraphTranslationRepository { get; }

        #endregion

        #region Countries
        /// <summary>
        /// The CountryRepository
        /// </summary>
        IGenericRepository<Country> CountryRepository { get; }

        /// <summary>
        /// The CountryTranslationRepository
        /// </summary>
        IGenericRepository<CountryTranslation> CountryTranslationRepository { get; }

        /// <summary>
        /// The SheetRepository
        /// </summary>
        IGenericRepository<Sheet> SheetRepository { get; }

        /// <summary>
        /// The SheetTranslationRepository
        /// </summary>
        IGenericRepository<SheetTranslation> SheetTranslationRepository { get; }

        #endregion

        #region Ressources

        /// <summary>
        /// The AuthorRepository.
        /// </summary>
        IGenericRepository<Author> AuthorRepository { get; }

        /// <summary>
        /// The ThemeRepository.
        /// </summary>
        IGenericRepository<Theme> ThemeRepository { get; }

        /// <summary>
        /// The ThemeTranslationRepository.
        /// </summary>
        IGenericRepository<ThemeTranslation> ThemeTranslationRepository { get; }

        /// <summary>
        /// The AreaRepository.
        /// </summary>
        IGenericRepository<Area> AreaRepository { get; }

        /// <summary>
        /// The AreaTranslationRepository.
        /// </summary>
        IGenericRepository<AreaTranslation> AreaTranslationRepository { get; }

        /// <summary>
        /// The publication repository.
        /// </summary>
        IGenericRepository<Publication> PublicationRepository { get; }

        /// <summary>
        /// The Publication Translation Repository
        /// </summary>
        IGenericRepository<PublicationTranslation> PublicationTranslationRepository { get; }

        /// <summary>
        /// The PublicationThemeRepository.
        /// </summary>
        IGenericRepository<PublicationTheme> PublicationThemeRepository { get; }

        #endregion

        #region Newsletters
        /// <summary>
        /// The SubscriberRepository
        /// </summary>
        IGenericRepository<Subscriber> SubscriberRepository { get; }

        /// <summary>
        /// The SubscriberRepository
        /// </summary>
        IGenericRepository<NewsletterMail> NewsletterMailRepository { get; }

        /// <summary>
        /// The SubscriberRepository
        /// </summary>
        IGenericRepository<NewsletterMailTranslation> NewsletterMailTranslationRepository { get; }
        #endregion

        #region Partners
        /// <summary>
        /// The PartnerRepository
        /// </summary>
        IGenericRepository<Partner> PartnerRepository { get; }
        #endregion

        #region contact
        /// <summary>
        /// The ContactMessageRepository
        /// </summary>
        IGenericRepository<ContactMessage> ContactMessageRepository { get; }
        #endregion

        #region Save methode

        /// <summary>
        /// The save methode.
        /// </summary>
        void Save();

        #endregion
    }
}
