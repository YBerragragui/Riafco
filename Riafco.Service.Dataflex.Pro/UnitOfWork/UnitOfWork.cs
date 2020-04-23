using Riafco.Dal.Dataflex.Pro.Context;
using Riafco.Dal.Dataflex.Pro.Core;
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
    /// The unit of work class
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region context

        /// <summary>
        /// The context
        /// </summary>
        private readonly RiafcoContext _context;

        #endregion

        #region constructor
        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="context">Initialiser le context</param>
        public UnitOfWork(RiafcoContext context)
        {
            _context = context;
        }
        #endregion

        #region private attributes

        #region authorization

        /// <summary>
        /// The user respository.
        /// </summary>
        private IGenericRepository<User> _userRepository;

        /// <summary>
        /// The rule repository
        /// </summary>
        private IGenericRepository<Rule> _ruleRepository;

        /// <summary>
        /// The right Repository
        /// </summary>
        private IGenericRepository<UserRule> _userRuleRepository;

        #endregion

        #region language

        /// <summary>
        /// the language interface repository
        /// </summary>
        private IGenericRepository<Language> _languageRepository;

        #endregion

        #region activites
        /// <summary>
        /// The _activityRepository
        /// </summary>
        private IGenericRepository<Activity> _activityRepository;

        /// <summary>
        /// The _ActivityTranslationRepository.
        /// </summary>
        private IGenericRepository<ActivityTranslation> _activityTranslationRepository;

        /// <summary>
        /// The activityParagraphRepository.
        /// </summary>
        private IGenericRepository<ActivityParagraph> _activityParagraphRepository;

        /// <summary>
        /// The _ActivityParagraphRepository.
        /// </summary>
        private IGenericRepository<ActivityParagraphTranslation> _activityParagraphTraslationRepository;

        /// <summary>
        /// The _ActivityFileRepository.
        /// </summary>
        private IGenericRepository<ActivityFile> _activityFileRepository;

        /// <summary>
        /// The _ActivityFileTranslationRepository.
        /// </summary>
        private IGenericRepository<ActivityFileTranslation> _activityFileTranslationRepository;
        #endregion

        #region news
        /// <summary>
        /// The _newsRepository
        /// </summary>
        private IGenericRepository<Entity.Dataflex.Pro.News.News> _newsRepository;

        /// <summary>
        /// The _newsTranslationRepository
        /// </summary>
        private IGenericRepository<NewsTranslation> _newsTranslationRepository;
        #endregion

        #region countries
        /// <summary>
        /// The _countryRepository
        /// </summary>
        private IGenericRepository<Country> _countryRepository;

        /// <summary>
        /// The _countryTranslationRepository
        /// </summary>
        private IGenericRepository<CountryTranslation> _countryTranslationRepository;

        /// <summary>
        /// The _sheetRepository
        /// </summary>
        private IGenericRepository<Sheet> _sheetRepository;

        /// <summary>
        /// _sheetTranslationRepository
        /// </summary>
        private IGenericRepository<SheetTranslation> _sheetTranslationRepository;
        #endregion

        #region occurrences
        /// <summary>
        /// The _occurrenceRepository
        /// </summary>
        private IGenericRepository<Occurrence> _occurrenceRepository;

        /// <summary>
        /// The _occurrenceTranslationRepository
        /// </summary>
        private IGenericRepository<OccurrenceTranslation> _occurrenceTranslationRepository;
        #endregion

        #region About.
        /// <summary>
        /// The _sectionRepository
        /// </summary>
        private IGenericRepository<Section> _sectionRepository;

        /// <summary>
        /// The _sectionTranslationRepository
        /// </summary>
        private IGenericRepository<SectionTranslation> _sectionTranslationRepository;

        /// <summary>
        /// The sectionParagraphRepository.
        /// </summary>
        private IGenericRepository<SectionParagraph> _sectionParagraphRepository;

        /// <summary>
        /// The _SectionParagraphRepository.
        /// </summary>
        private IGenericRepository<SectionParagraphTranslation> _sectionParagraphTraslationRepository;

        /// <summary>
        /// The _SectionFileRepository.
        /// </summary>
        private IGenericRepository<SectionFile> _sectionFileRepository;

        /// <summary>
        /// The _SectionFileTranslationRepository.
        /// </summary>
        private IGenericRepository<SectionFileTranslation> _sectionFileTranslationRepository;

        /// <summary>
        /// The _StepRepository.
        /// </summary>
        private IGenericRepository<Step> _stepRepository;

        /// <summary>
        /// The _StepParagraphRepository _StepParagraphRepository.
        /// </summary>
        private IGenericRepository<StepParagraph> _stepParagraphRepository;

        /// <summary>
        /// The _StepParagraphTranslationRepository
        /// </summary>
        private IGenericRepository<StepParagraphTranslation> _stepParagraphTranslationRepository;
        #endregion

        #region Newsletters
        /// <summary>
        /// The _subscriberRepository
        /// </summary>
        private IGenericRepository<Subscriber> _subscriberRepository;

        /// <summary>
        /// The _newsletterMailRepository
        /// </summary>
        private IGenericRepository<NewsletterMail> _newsletterMailRepository;

        /// <summary>
        /// The _newsletterMailTranslationRepository
        /// </summary>
        private IGenericRepository<NewsletterMailTranslation> _newsletterMailTranslationRepository;
        #region ressources

        /// <summary>
        /// The _AuthorRepository
        /// </summary>
        private IGenericRepository<Author> _authorRepository;

        /// <summary>
        /// The _ThemeRepository.
        /// </summary>
        private IGenericRepository<Theme> _themeRepository;

        /// <summary>
        /// The _ThemeTranslationRepository
        /// </summary>
        private IGenericRepository<ThemeTranslation> _themeTranslationRepository;

        /// <summary>
        /// The _AreaRepository.
        /// </summary>
        private IGenericRepository<Area> _areaRepository;

        /// <summary>
        /// The _AreaTranslationRepository.
        /// </summary>
        private IGenericRepository<AreaTranslation> _areaTranslationRepository;

        /// <summary>
        /// The _PublicationRepository.
        /// </summary>
        private IGenericRepository<Publication> _publicationRepository;

        /// <summary>
        /// The _PublicationTranslationRepository.
        /// </summary>
        private IGenericRepository<PublicationTranslation> _publicationTranslationRepository;

        /// <summary>
        /// The _PublicationThemeRepository.
        /// </summary>
        private IGenericRepository<PublicationTheme> _publicationThemeRepository;

        #endregion
        #endregion

        #region Partners
        /// <summary>
        /// The _partnerRepository
        /// </summary>
        private IGenericRepository<Partner> _partnerRepository;
        #endregion

        #region Contact
        private IGenericRepository<ContactMessage> _contactMessageRepository;
        #endregion

        #endregion

        #region public methods

        #region Authorization

        /// <summary>
        /// The user repository
        /// </summary>
        public IGenericRepository<User> UserRepository => _userRepository ?? (_userRepository = new GenericRepository<User>(_context));

        /// <summary>
        /// The rule repository
        /// </summary>
        public IGenericRepository<Rule> RuleRepository => _ruleRepository ?? (_ruleRepository = new GenericRepository<Rule>(_context));

        /// <summary>
        /// The user rule repository
        /// </summary>
        public IGenericRepository<UserRule> UserRuleRepository => _userRuleRepository ?? (_userRuleRepository = new GenericRepository<UserRule>(_context));

        #endregion

        #region Language
        /// <summary>
        /// Get the LanguageRepository
        /// </summary>
        public IGenericRepository<Language> LanguageRepository => _languageRepository ?? (_languageRepository = new GenericRepository<Language>(_context));

        #endregion

        #region Activites

        /// <summary>
        /// Set activite repository
        /// </summary>
        public IGenericRepository<Activity> ActivityRepository => _activityRepository ?? (_activityRepository = new GenericRepository<Activity>(_context));

        /// <summary>
        /// Set activity translation repository
        /// </summary>
        public IGenericRepository<ActivityTranslation> ActivityTranslationRepository => _activityTranslationRepository ?? (_activityTranslationRepository = new GenericRepository<ActivityTranslation>(_context));

        /// <summary>
        /// The activity paragraph repository.
        /// </summary>
        public IGenericRepository<ActivityParagraph> ActivityParagraphRepository => _activityParagraphRepository ?? (_activityParagraphRepository = new GenericRepository<ActivityParagraph>(_context));

        /// <summary>
        /// The actity paraghrap.
        /// </summary>
        public IGenericRepository<ActivityParagraphTranslation> ActivityParagraphTraslationRepository => _activityParagraphTraslationRepository ?? (_activityParagraphTraslationRepository = new GenericRepository<ActivityParagraphTranslation>(_context));

        /// <summary>
        /// The ActivityFileRepository
        /// </summary>
        public IGenericRepository<ActivityFile> ActivityFileRepository => _activityFileRepository ?? (_activityFileRepository = new GenericRepository<ActivityFile>(_context));

        /// <summary>
        /// The ActivityFileTranslationRepository
        /// </summary>
        public IGenericRepository<ActivityFileTranslation> ActivityFileTranslationRepository => _activityFileTranslationRepository ?? (_activityFileTranslationRepository = new GenericRepository<ActivityFileTranslation>(_context));

        #endregion

        #region News
        /// <summary>
        /// Set the NewsRepository 
        /// </summary>
        public IGenericRepository<Entity.Dataflex.Pro.News.News> NewsRepository => _newsRepository ?? (_newsRepository = new GenericRepository<Entity.Dataflex.Pro.News.News>(_context));

        /// <summary>
        /// Set NewsTranslationRepository
        /// </summary>
        public IGenericRepository<NewsTranslation> NewsTranslationRepository => _newsTranslationRepository ?? (_newsTranslationRepository = new GenericRepository<NewsTranslation>(_context));

        #endregion

        #region countries
        /// <summary>
        /// Set CountryRepository
        /// </summary>
        public IGenericRepository<Country> CountryRepository => _countryRepository ?? (_countryRepository = new GenericRepository<Country>(_context));

        /// <summary>
        /// Set CountryTranslationRepository
        /// </summary>
        public IGenericRepository<CountryTranslation> CountryTranslationRepository => _countryTranslationRepository ?? (_countryTranslationRepository = new GenericRepository<CountryTranslation>(_context));

        /// <summary>
        /// Set SheetRepository
        /// </summary>
        public IGenericRepository<Sheet> SheetRepository => _sheetRepository ?? (_sheetRepository = new GenericRepository<Sheet>(_context));

        /// <summary>
        /// Set SheetTranslationRepository
        /// </summary>
        public IGenericRepository<SheetTranslation> SheetTranslationRepository => _sheetTranslationRepository ?? (_sheetTranslationRepository = new GenericRepository<SheetTranslation>(_context));

        #endregion

        #region Occurrences
        /// <summary>
        /// Set OccurrenceRepository
        /// </summary>
        public IGenericRepository<Occurrence> OccurrenceRepository => _occurrenceRepository ?? (_occurrenceRepository = new GenericRepository<Occurrence>(_context));

        /// <summary>
        /// Set OccurrenceTranslationRepository
        /// </summary>
        public IGenericRepository<OccurrenceTranslation> OccurrenceTranslationRepository => _occurrenceTranslationRepository ?? (_occurrenceTranslationRepository = new GenericRepository<OccurrenceTranslation>(_context));
        #endregion

        #region About
        /// <summary>
        /// Set SectionRepository
        /// </summary>
        public IGenericRepository<Section> SectionRepository => _sectionRepository ?? (_sectionRepository = new GenericRepository<Section>(_context));

        /// <summary>
        /// Set SectionTranslationRepository
        /// </summary>
        public IGenericRepository<SectionTranslation> SectionTranslationRepository => _sectionTranslationRepository ?? (_sectionTranslationRepository = new GenericRepository<SectionTranslation>(_context));

        /// <summary>
        /// The section paragraph repository.
        /// </summary>
        public IGenericRepository<SectionParagraph> SectionParagraphRepository => _sectionParagraphRepository ?? (_sectionParagraphRepository = new GenericRepository<SectionParagraph>(_context));

        /// <summary>
        /// The actity paraghrap.
        /// </summary>
        public IGenericRepository<SectionParagraphTranslation> SectionParagraphTraslationRepository => _sectionParagraphTraslationRepository ?? (_sectionParagraphTraslationRepository = new GenericRepository<SectionParagraphTranslation>(_context));

        /// <summary>
        /// The SectionFileRepository
        /// </summary>
        public IGenericRepository<SectionFile> SectionFileRepository => _sectionFileRepository ?? (_sectionFileRepository = new GenericRepository<SectionFile>(_context));

        /// <summary>
        /// The SectionFileTranslationRepository
        /// </summary>
        public IGenericRepository<SectionFileTranslation> SectionFileTranslationRepository => _sectionFileTranslationRepository ?? (_sectionFileTranslationRepository = new GenericRepository<SectionFileTranslation>(_context));

        /// <summary>
        /// Get StepRepository
        /// </summary>
        public IGenericRepository<Step> StepRepository => this._stepRepository ?? (this._stepRepository = new GenericRepository<Step>(_context));

        /// <summary>
        /// Get StepParagraphRepository
        /// </summary>
        public IGenericRepository<StepParagraph> StepParagraphRepository => this._stepParagraphRepository ?? (this._stepParagraphRepository = new GenericRepository<StepParagraph>(_context));

        /// <summary>
        /// Get StepParagraphTranslationRepository
        /// </summary>
        public IGenericRepository<StepParagraphTranslation> StepParagraphTranslationRepository => this._stepParagraphTranslationRepository ?? (this._stepParagraphTranslationRepository = new GenericRepository<StepParagraphTranslation>(_context));

        #endregion

        #region Ressources
        /// <summary>
        /// The AuthorRepository.
        /// </summary>
        public IGenericRepository<Author> AuthorRepository => _authorRepository ?? (_authorRepository = new GenericRepository<Author>(_context));

        /// <summary>
        /// The ThemeRepository
        /// </summary>
        public IGenericRepository<Theme> ThemeRepository => _themeRepository ?? (_themeRepository = new GenericRepository<Theme>(_context));

        /// <summary>
        /// The ThemeTranslationRepository.
        /// </summary>
        public IGenericRepository<ThemeTranslation> ThemeTranslationRepository => _themeTranslationRepository ?? (_themeTranslationRepository = new GenericRepository<ThemeTranslation>(_context));

        /// <summary>
        /// The AreaRepository
        /// </summary>
        public IGenericRepository<Area> AreaRepository => _areaRepository ?? (_areaRepository = new GenericRepository<Area>(_context));

        /// <summary>
        /// The AreaTranslationRepository
        /// </summary>
        public IGenericRepository<AreaTranslation> AreaTranslationRepository => _areaTranslationRepository ?? (_areaTranslationRepository = new GenericRepository<AreaTranslation>(_context));

        /// <summary>
        ///  The PublicationRepository.
        /// </summary>
        public IGenericRepository<Publication> PublicationRepository => _publicationRepository ?? (_publicationRepository = new GenericRepository<Publication>(_context));

        /// <summary>
        /// The PublicationTranslationRepository
        /// </summary>
        public IGenericRepository<PublicationTranslation> PublicationTranslationRepository => _publicationTranslationRepository ?? (_publicationTranslationRepository = new GenericRepository<PublicationTranslation>(_context));

        /// <summary>
        /// The PublicationThemeRepository.
        /// </summary>
        public IGenericRepository<PublicationTheme> PublicationThemeRepository => _publicationThemeRepository ?? (_publicationThemeRepository = new GenericRepository<PublicationTheme>(_context));

        #endregion

        #region Newsletters
        /// <summary>
        /// Set SubscriberRepository
        /// </summary>
        public IGenericRepository<Subscriber> SubscriberRepository => _subscriberRepository ?? (_subscriberRepository = new GenericRepository<Subscriber>(_context));

        /// <summary>
        /// Set NewsletterMailRepository
        /// </summary>
        public IGenericRepository<NewsletterMail> NewsletterMailRepository => _newsletterMailRepository ?? (_newsletterMailRepository = new GenericRepository<NewsletterMail>(_context));

        /// <summary>
        /// Set NewsletterMailTranslationRepository
        /// </summary>
        public IGenericRepository<NewsletterMailTranslation> NewsletterMailTranslationRepository => _newsletterMailTranslationRepository ?? (_newsletterMailTranslationRepository = new GenericRepository<NewsletterMailTranslation>(_context));


        /// <summary>
        /// The PartnerRepository
        /// </summary>
        public IGenericRepository<Partner> PartnerRepository => _partnerRepository ?? (_partnerRepository = new GenericRepository<Partner>(_context));

        #endregion

        #region Contact
        public IGenericRepository<ContactMessage> ContactMessageRepository => _contactMessageRepository ?? (_contactMessageRepository = new GenericRepository<ContactMessage>(_context));
        #endregion

        #region save method

        /// <summary>
        /// Save change into database.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        #endregion

        #endregion
    }
}
