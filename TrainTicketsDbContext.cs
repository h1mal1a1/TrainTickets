using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;

namespace TrainTickets;

public class TrainTicketsDbContext
{
    public class Stations
    {
        public int IdStation;
        public string StationName;
        public List<Registration> LstDepartures { get; set; } = [];
        public List<Registration> LstArrivals { get; set; } = [];
        
    }
    public class StationsConfig: IEntityTypeConfiguration<Stations>
    {
        public void Configure(EntityTypeBuilder<Stations> builder)
        {
            builder.ToTable("Stations");
            builder.HasKey(h=>h.IdStation);
            
            builder
                .Property(p => p.IdStation)
                .HasColumnName("IdStation")
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();
            
            builder.Property(p => p.StationName)
                .HasColumnName("StationName")
                .HasMaxLength(100);

            builder.HasIndex(p => p.IdStation);
            builder.HasIndex(p => p.StationName).IsUnique();
            
            builder
                .HasMany(r => r.LstDepartures)
                .WithOne(s => s.DepartureStation);
            builder
                .HasMany(r => r.LstArrivals)
                .WithOne(s => s.ArrivalStation);
        }
    }
    public class ClassTypes
    {
        public int IdClassType;
        public string TypeName;
        public List<Registration> LstClassTypes { get; set; } = [];
    }
    public class ClassTypesConfig: IEntityTypeConfiguration<ClassTypes>
    {
        public void Configure(EntityTypeBuilder<ClassTypes> builder)
        {
            builder.ToTable("ClassTypes");
            builder.HasKey(h=>h.IdClassType);
            
            builder
                .Property(p => p.IdClassType)
                .HasColumnName("IdClassType")
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();
            
            builder.Property(p => p.TypeName)
                .HasColumnName("TypeName")
                .HasMaxLength(100);

            builder.HasIndex(p => p.IdClassType);
            builder.HasIndex(p => p.TypeName).IsUnique();
            
            builder
                .HasMany(r => r.LstClassTypes)
                .WithOne(s => s.ClassType);
        }
    }
    public class BookingStatuses
    {
        public int IdBookingStatus;
        public string BookingName;
        public List<Registration> LstBookingStatuses { get; set; } = [];
    }
    public class BookingStatusesConfig: IEntityTypeConfiguration<BookingStatuses>
    {
        public void Configure(EntityTypeBuilder<BookingStatuses> builder)
        {
            builder.ToTable("BookingStatuses");
            builder.HasKey(h=>h.IdBookingStatus);
            
            builder
                .Property(p => p.IdBookingStatus)
                .HasColumnName("IdBookingStatus")
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();
            
            builder.Property(p => p.BookingName)
                .HasColumnName("BookingName")
                .HasMaxLength(100);

            builder.HasIndex(p => p.IdBookingStatus);
            builder.HasIndex(p => p.BookingName).IsUnique();
            
            builder
                .HasMany(r => r.LstBookingStatuses)
                .WithOne(s => s.BookingStatuse);
        }
    }

    public class Names
    {
        public int IdName;
        public string Name;
        public List<Registration> LstNames { get; set; } = [];
    }
    public class NamesConfig: IEntityTypeConfiguration<Names>
    {
        public void Configure(EntityTypeBuilder<Names> builder)
        {
            builder.ToTable("Names");
            builder.HasKey(h=>h.IdName);
            
            builder
                .Property(p => p.IdName)
                .HasColumnName("IdName")
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();
            
            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasMaxLength(100);

            builder.HasIndex(p => p.IdName);
            builder.HasIndex(p => p.Name).IsUnique();
            
            builder
                .HasMany(r => r.LstNames)
                .WithOne(s => s.Name);
        }
    }
    public class LastNames
    {
        public int IdLastName;
        public string LastName;
        public List<Registration> LstLastNames { get; set; } = [];
    }
    public class LastNamesConfig: IEntityTypeConfiguration<LastNames>
    {
        public void Configure(EntityTypeBuilder<LastNames> builder)
        {
            builder.ToTable("LastNames");
            builder.HasKey(h=>h.IdLastName);
            
            builder
                .Property(p => p.IdLastName)
                .HasColumnName("IdLastName")
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();
            
            builder.Property(p => p.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(100);

            builder.HasIndex(p => p.IdLastName);
            builder.HasIndex(p => p.LastName).IsUnique();
            
            builder
                .HasMany(r => r.LstLastNames)
                .WithOne(s => s.LastName);
        }
    }
    public class Patronymics
    {
        public int IdPatronymic;
        public string Name;
        public List<Registration> LstPatronymics { get; set; } = [];
    }
    public class PatronymicsConfig: IEntityTypeConfiguration<Patronymics>
    {
        public void Configure(EntityTypeBuilder<Patronymics> builder)
        {
            builder.ToTable("Patronymics");
            builder.HasKey(h=>h.IdPatronymic);
            
            builder
                .Property(p => p.IdPatronymic)
                .HasColumnName("IdPatronymic")
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();
            
            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasMaxLength(100);

            builder.HasIndex(p => p.IdPatronymic);
            builder.HasIndex(p => p.Name).IsUnique();
            
            builder
                .HasMany(r => r.LstPatronymics)
                .WithOne(s => s.Patronymic);
        }
    }
    public class Registration
    {
        //Уникальный идентификатор билета
        public long TicketId;
        //Номер поезда
        public int TrainNumber;
        //Станция отправления
        public int IdDepartureStation;
        // Станция назначения
        public int IdArrivalStation;
        //Дата и время отправления
        public DateTime DepartureTime;
        //Дата и время прибытия
        public DateTime ArrivalTime;
        //Время регистрации
        public DateTime DateRegistration;
        //Номер вагона
        public int CarriageNumber;
        //Номер места
        public int SeatNumber;
        //Стоимость билета
        public int Price;
        //Тип билета(плацкарт, купе, СВ и т. д.)
        public int IdClassType; 
        //Статус брони(забронирован, оплачен, отменён)
        public int IdBookingStatus;
        //Имя пассажира
        public int IdName;
        //Фамилия пассажира
        public int IdLastName;
        //Отчество пассажира
        public int IdPatronymic;
        public ClassTypes ClassType;
        public Names Name;
        public LastNames LastName;
        public Patronymics Patronymic;
        public BookingStatuses BookingStatuse;
        public Stations DepartureStation;
        public Stations ArrivalStation;
    }
    public class RegistrationConfig: IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder.ToTable("Registration");
            builder.HasKey(r=>r.TicketId);
            builder.Property(p => p.TicketId)
                .HasColumnName("TicketId")
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();
            
            builder.Property(p => p.TrainNumber).HasColumnName("TrainNumber");
            builder.Property(p => p.IdDepartureStation).HasColumnName("IdDepartureStation");
            builder.Property(p => p.IdArrivalStation).HasColumnName("IdArrivalStation");
            builder.Property(p => p.DepartureTime).HasColumnName("DepartureTime");
            builder.Property(p => p.DateRegistration).HasColumnName("DateReg");
            builder.Property(p => p.ArrivalTime).HasColumnName("ArrivalTime");
            builder.Property(p => p.CarriageNumber).HasColumnName("CarriageNumber");
            builder.Property(p => p.SeatNumber).HasColumnName("SeatNumber");
            builder.Property(p => p.Price).HasColumnName("Price");
            builder.Property(p => p.IdClassType).HasColumnName("IdClassType");
            builder.Property(p => p.IdBookingStatus).HasColumnName("IdBookingStatus");
            builder.Property(p => p.IdName).HasColumnName("IdName");
            builder.Property(p => p.IdLastName).HasColumnName("IdLastName");
            builder.Property(p => p.IdPatronymic).HasColumnName("IdPatronymic");

            builder
                .HasOne(r => r.ClassType)
                .WithMany(c => c.LstClassTypes)
                .HasForeignKey(r => r.IdClassType)
                .HasPrincipalKey(ha=>ha.IdClassType)
                .IsRequired();
            
            builder
                .HasOne(r => r.Name)
                .WithMany(c => c.LstNames)
                .HasForeignKey(r => r.IdName)
                .HasPrincipalKey(g=>g.IdName)
                .IsRequired();
            
            builder
                .HasOne(r => r.LastName)
                .WithMany(c => c.LstLastNames)
                .HasForeignKey(r => r.IdLastName)
                .HasPrincipalKey(n=>n.IdLastName)
                .IsRequired();
            
            builder
                .HasOne(r => r.Patronymic)
                .WithMany(c => c.LstPatronymics)
                .HasForeignKey(r => r.IdPatronymic)
                .HasPrincipalKey(sc => sc.IdPatronymic)
                .IsRequired();
            
            builder
                .HasOne(r => r.BookingStatuse)
                .WithMany(c => c.LstBookingStatuses)
                .HasForeignKey(r => r.IdBookingStatus)
                .HasPrincipalKey(w=>w.IdBookingStatus)
                .IsRequired();
            
            builder
                .HasOne(r => r.DepartureStation)
                .WithMany(c => c.LstDepartures)
                .HasForeignKey(r => r.IdDepartureStation)
                .HasPrincipalKey(c=>c.IdStation);
            builder
                .HasOne(r => r.ArrivalStation)
                .WithMany(c => c.LstArrivals)
                .HasForeignKey(r => r.IdArrivalStation)
                .HasPrincipalKey(c=>c.IdStation);
        }
    }
    public class DbConfig
    {
        public string ServerName { get; set; } = string.Empty;
        public string DbName { get; set; } = string.Empty;
        public int Port { get; set; }
        public int ConnectionTimeout { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int CommandTimeout { get; set; }
        public string SqlConnectionString { get; set; } = string.Empty;

        public bool IsEmpty()
        {
            if (ConnectionTimeout.Equals(0)) ConnectionTimeout = 30;

            if (ServerName.Equals(string.Empty)) return true;
            if (DbName.Equals(string.Empty)) return true;
            if (Port.Equals(0)) return true;
            return false;
        }

        public void SetCnnString()
        {
            SqlConnectionString = $"Host={ServerName};" +
                                  $"Port={Port};" + 
                                  $"Database={DbName};" +
                                  $"Username={Username};" +
                                  $"Password={Password};" +
                                  $"Timeout={ConnectionTimeout};" +
                                  $"CommandTimeout={CommandTimeout}";
        }
    }
    public class AppDbContext : DbContext
    {
        public DbSet<ClassTypes> ClassTypes { get; set; }
        public DbSet<Names> Names { get; set; }
        public DbSet<LastNames> LastNames { get; set; }
        public DbSet<Patronymics> Patronymics { get; set; }
        public DbSet<BookingStatuses> BookingStatuses { get; set; }
        public DbSet<Stations> Stations { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        // private readonly string ConnectionString;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClassTypesConfig());
            modelBuilder.ApplyConfiguration(new NamesConfig());
            modelBuilder.ApplyConfiguration(new LastNamesConfig());
            modelBuilder.ApplyConfiguration(new PatronymicsConfig());
            modelBuilder.ApplyConfiguration(new BookingStatusesConfig());
            modelBuilder.ApplyConfiguration(new StationsConfig());
            modelBuilder.ApplyConfiguration(new RegistrationConfig());
            //modelBuilder.Entity<Registration>().ToTable(tb => tb.HasTrigger("Nametrigger"));
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optBuilder)
        {
            string notInDockComp = "Host=localhost;Port=5434;Database=postgres;Username=postgres;Password=example;";
            //string inDockComp = "Host=pg;Port=5432;Database=postgres;Username=postgres;Password=example;";
            optBuilder.UseNpgsql(notInDockComp);
            // options => options.EnableRetryOnFailure(
            //     maxRetryCount: 5,
            //     maxRetryDelay: TimeSpan.FromSeconds(10),
            //     errorCodesToAdd: null));
            optBuilder.UseLoggerFactory(LoggerFactory.Create(builder => 
                builder.AddConsole().AddFilter(level => level >= LogLevel.Information)));
            //optBuilder.UseLoggerFactory(Logger)
            //optBuilder.LogTo(Console.WriteLine);
            
        }
    }
}