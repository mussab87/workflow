using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WorkFlow.Models;

public partial class Workflow2Context : DbContext
{
    public Workflow2Context()
    {
    }

    public Workflow2Context(DbContextOptions<Workflow2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Action> Actions { get; set; }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<ApplicationLable> ApplicationLables { get; set; }

    public virtual DbSet<ApplicationLevel> ApplicationLevels { get; set; }

    public virtual DbSet<ApplicationLevelAssigned> ApplicationLevelAssigneds { get; set; }

    public virtual DbSet<ApplicationLink> ApplicationLinks { get; set; }

    public virtual DbSet<ApplicationNotification> ApplicationNotifications { get; set; }

    public virtual DbSet<ApplicationProcuderDetail> ApplicationProcuderDetails { get; set; }

    public virtual DbSet<ApplicationRequirement> ApplicationRequirements { get; set; }

    public virtual DbSet<ApplicationRequirementDetail> ApplicationRequirementDetails { get; set; }

    public virtual DbSet<ArchivesMaster> ArchivesMasters { get; set; }

    public virtual DbSet<AttachmentDetail> AttachmentDetails { get; set; }

    public virtual DbSet<AttachmentMaster> AttachmentMasters { get; set; }

    public virtual DbSet<AttachmentsType> AttachmentsTypes { get; set; }

    public virtual DbSet<CheckListDetail> CheckListDetails { get; set; }

    public virtual DbSet<DepManager> DepManagers { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DisplayLink> DisplayLinks { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<FnApplicationLevelAssigned> FnApplicationLevelAssigneds { get; set; }

    public virtual DbSet<FnEmp> FnEmps { get; set; }

    public virtual DbSet<LinkCondation> LinkCondations { get; set; }

    public virtual DbSet<ManagerType> ManagerTypes { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<NotificationApp> NotificationApps { get; set; }

    public virtual DbSet<Notifier> Notifiers { get; set; }

    public virtual DbSet<RelativeType> RelativeTypes { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestDetail> RequestDetails { get; set; }

    public virtual DbSet<RequestDetailsAttach> RequestDetailsAttaches { get; set; }

    public virtual DbSet<RequestDetailsStatus> RequestDetailsStatuses { get; set; }

    public virtual DbSet<RequestLevel> RequestLevels { get; set; }

    public virtual DbSet<RequestLevelAssigned> RequestLevelAssigneds { get; set; }

    public virtual DbSet<RequestStatus> RequestStatuses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleUser> RoleUsers { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<SharedTable> SharedTables { get; set; }

    public virtual DbSet<SharedTableDatum> SharedTableData { get; set; }

    public virtual DbSet<SystemInfo> SystemInfos { get; set; }

    public virtual DbSet<Tool> Tools { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local);Database=workflow2;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_100_BIN");

        modelBuilder.Entity<Action>(entity =>
        {
            entity.Property(e => e.ActionId).HasColumnName("ActionID");
            entity.Property(e => e.ActionInUse).HasColumnName("ActionInUSe");
            entity.Property(e => e.ActionName).HasMaxLength(50);
            entity.Property(e => e.ActionNameArabic).HasMaxLength(50);
            entity.Property(e => e.ForApplicationId).HasColumnName("ForApplication_Id");
        });

        modelBuilder.Entity<Application>(entity =>
        {
            entity.Property(e => e.ApplicationId).HasColumnName("Application_Id");
            entity.Property(e => e.ApplicationInUse).HasColumnName("Application_In_Use");
            entity.Property(e => e.ApplicationNameAr)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Application_Name_Ar");
            entity.Property(e => e.ApplicationNameEng)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Application_Name_Eng");
            entity.Property(e => e.CrDate)
                .HasColumnType("datetime")
                .HasColumnName("Cr_Date");
            entity.Property(e => e.CrEmpId)
                .HasMaxLength(128)
                .HasColumnName("Cr_Emp_Id");
            entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");
            entity.Property(e => e.SectionId).HasColumnName("Section_Id");
            entity.Property(e => e.UpDate)
                .HasColumnType("datetime")
                .HasColumnName("Up_Date");
            entity.Property(e => e.UpEmpId)
                .HasMaxLength(128)
                .HasColumnName("Up_Emp_Id");

            entity.HasOne(d => d.Department).WithMany(p => p.Applications)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Applications_Department");

            entity.HasOne(d => d.Section).WithMany(p => p.Applications)
                .HasForeignKey(d => d.SectionId)
                .HasConstraintName("FK_Applications_Section");
        });

        modelBuilder.Entity<ApplicationLable>(entity =>
        {
            entity.ToTable("ApplicationLable");

            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.FromPort)
                .HasMaxLength(50)
                .HasColumnName("fromPort");
            entity.Property(e => e.Movex).HasColumnName("movex");
            entity.Property(e => e.Movey).HasColumnName("movey");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.TemplateId)
                .HasMaxLength(50)
                .HasColumnName("templateId");
            entity.Property(e => e.Text)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("text");
            entity.Property(e => e.ToPort)
                .HasMaxLength(50)
                .HasColumnName("toPort");

            entity.HasOne(d => d.FromApplicationLevel).WithMany(p => p.ApplicationLableFromApplicationLevels)
                .HasForeignKey(d => d.FromApplicationLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationLable_Application_Levels");

            entity.HasOne(d => d.ToApplicationLevel).WithMany(p => p.ApplicationLableToApplicationLevels)
                .HasForeignKey(d => d.ToApplicationLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationLable_ApplicationToLable");
        });

        modelBuilder.Entity<ApplicationLevel>(entity =>
        {
            entity.ToTable("Application_Levels");

            entity.Property(e => e.ApplicationLevelId).HasColumnName("Application_Level_Id");
            entity.Property(e => e.ApplicationId).HasColumnName("Application_Id");
            entity.Property(e => e.ApplicationLevelInUse).HasColumnName("Application_Level_InUse");
            entity.Property(e => e.ApplicationLevelIndex).HasColumnName("Application_Level_Index");
            entity.Property(e => e.ApplicationLevelName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Application_Level_Name");
            entity.Property(e => e.ApplicationLevelUpDate)
                .HasColumnType("date")
                .HasColumnName("Application_Level_Up_Date");
            entity.Property(e => e.ApplicationLevelUpEmpId).HasColumnName("Application_Level_Up_EmpId");
            entity.Property(e => e.ArchivesMasterId).HasColumnName("Archives_master_Id");
            entity.Property(e => e.CanConversion).HasColumnName("Can_Conversion");
            entity.Property(e => e.CanEndRequest).HasColumnName("Can_End_Request");
            entity.Property(e => e.CanReject).HasColumnName("Can_Reject");
            entity.Property(e => e.CanReturn).HasColumnName("Can_Return");
            entity.Property(e => e.CanShowAttach).HasColumnName("Can_Show_Attach");
            entity.Property(e => e.Fill).HasColumnName("fill");
            entity.Property(e => e.Notification).HasMaxLength(50);
            entity.Property(e => e.ProcuderName).HasMaxLength(50);
            entity.Property(e => e.Tbname)
                .HasMaxLength(50)
                .HasColumnName("TBName");
            entity.Property(e => e.TemplateId).HasColumnName("templateId");
            entity.Property(e => e.X).HasColumnName("x");
            entity.Property(e => e.Y).HasColumnName("y");

            entity.HasOne(d => d.Application).WithMany(p => p.ApplicationLevels)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Application_Levels_Applications");

            entity.HasOne(d => d.ArchivesMaster).WithMany(p => p.ApplicationLevels)
                .HasForeignKey(d => d.ArchivesMasterId)
                .HasConstraintName("FK_Application_Levels_Archives_master");
        });

        modelBuilder.Entity<ApplicationLevelAssigned>(entity =>
        {
            entity.ToTable("Application_Level_Assigned");

            entity.Property(e => e.ApplicationLevelAssignedId).HasColumnName("Application_Level_Assigned_Id");
            entity.Property(e => e.ApplicationLevelId).HasColumnName("Application_Level_Id");
            entity.Property(e => e.AssginTypeId).HasColumnName("AssginTypeID");
            entity.Property(e => e.AssignedInUse).HasColumnName("Assigned_In_Use");
            entity.Property(e => e.AssignedToEmpId).HasColumnName("Assigned_To_Emp_Id");
            entity.Property(e => e.CrDate)
                .HasColumnType("datetime")
                .HasColumnName("Cr_Date");
            entity.Property(e => e.CrEmpId)
                .HasMaxLength(128)
                .HasColumnName("Cr_Emp_Id");
            entity.Property(e => e.ManagerTypeId).HasColumnName("ManagerTypeID");
            entity.Property(e => e.UpDate)
                .HasColumnType("datetime")
                .HasColumnName("Up_Date");
            entity.Property(e => e.UpEmpId)
                .HasMaxLength(128)
                .HasColumnName("Up_Emp_Id");

            entity.HasOne(d => d.ApplicationLevel).WithMany(p => p.ApplicationLevelAssigneds)
                .HasForeignKey(d => d.ApplicationLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Application_Level_Assigned_Application_Level_Assigned");
        });

        modelBuilder.Entity<ApplicationLink>(entity =>
        {
            entity.HasKey(e => e.ApplictionLinkId);

            entity.ToTable("ApplicationLink");

            entity.Property(e => e.FromTapplicationLevelId).HasColumnName("FromTApplicationLevelId");
            entity.Property(e => e.Length).HasColumnName("length");
            entity.Property(e => e.TemplateId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("templateId");

            entity.HasOne(d => d.FromTapplicationLevel).WithMany(p => p.ApplicationLinkFromTapplicationLevels)
                .HasForeignKey(d => d.FromTapplicationLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationLink_ApplicationFromLink");

            entity.HasOne(d => d.ToApplicationLevel).WithMany(p => p.ApplicationLinkToApplicationLevels)
                .HasForeignKey(d => d.ToApplicationLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationLink_Application_LevelsToLink");
        });

        modelBuilder.Entity<ApplicationNotification>(entity =>
        {
            entity.ToTable("ApplicationNotification");

            entity.HasIndex(e => new { e.ActionId, e.ApplictionLinkId, e.ToEmpId }, "NonClusteredIndex-20240917-133747").IsUnique();

            entity.Property(e => e.ApplicationNotificationId).HasColumnName("ApplicationNotificationID");
            entity.Property(e => e.ActionId).HasColumnName("ActionID");

            entity.HasOne(d => d.Action).WithMany(p => p.ApplicationNotifications)
                .HasForeignKey(d => d.ActionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationNotification_ApplicationNotification");

            entity.HasOne(d => d.ApplictionLink).WithMany(p => p.ApplicationNotifications)
                .HasForeignKey(d => d.ApplictionLinkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationNotification_ApplicationLink");

            entity.HasOne(d => d.ToEmp).WithMany(p => p.ApplicationNotifications)
                .HasForeignKey(d => d.ToEmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationNotification_Employees");
        });

        modelBuilder.Entity<ApplicationProcuderDetail>(entity =>
        {
            entity.HasKey(e => e.ProcuderDetailId).HasName("PK_ProcuderDetail");

            entity.ToTable("ApplicationProcuderDetail");

            entity.Property(e => e.ApplicationLevelId).HasColumnName("Application_Level_Id");
            entity.Property(e => e.ApplicationRequirementId).HasColumnName("Application_Requirement_Id");
            entity.Property(e => e.ColumnName).HasMaxLength(50);

            entity.HasOne(d => d.ApplicationLevel).WithMany(p => p.ApplicationProcuderDetails)
                .HasForeignKey(d => d.ApplicationLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationProcuderDetailPr");

            entity.HasOne(d => d.ApplicationRequirement).WithMany(p => p.ApplicationProcuderDetails)
                .HasForeignKey(d => d.ApplicationRequirementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationProcuderDetail_Application_Requirement");
        });

        modelBuilder.Entity<ApplicationRequirement>(entity =>
        {
            entity.ToTable("Application_Requirement");

            entity.Property(e => e.ApplicationRequirementId).HasColumnName("Application_Requirement_Id");
            entity.Property(e => e.ApplicationId).HasColumnName("Application_Id");
            entity.Property(e => e.ApplicationLevelId).HasColumnName("Application_Level_Id");
            entity.Property(e => e.ApplicationRequirementInUse).HasColumnName("Application_Requirement_In_Use");
            entity.Property(e => e.ArchivesMasterId).HasColumnName("Archives_master_Id");
            entity.Property(e => e.ColumnNameValue)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column_Name_Value");
            entity.Property(e => e.CrDate)
                .HasColumnType("datetime")
                .HasColumnName("Cr_Date");
            entity.Property(e => e.CrEmpId).HasColumnName("Cr_Emp_Id");
            entity.Property(e => e.FixId).HasMaxLength(50);
            entity.Property(e => e.FnRun).HasMaxLength(50);
            entity.Property(e => e.InStart).HasColumnName("In_Start");
            entity.Property(e => e.IsRequired).HasColumnName("Is_Required");
            entity.Property(e => e.SharedTableId).HasColumnName("Shared_Table_Id");
            entity.Property(e => e.ToolsId).HasColumnName("Tools_Id");
            entity.Property(e => e.UpDate)
                .HasColumnType("datetime")
                .HasColumnName("Up_Date");
            entity.Property(e => e.UpEmpId).HasColumnName("Up_Emp_Id");

            entity.HasOne(d => d.Application).WithMany(p => p.ApplicationRequirements)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Application_Requirement_Applications1");

            entity.HasOne(d => d.ApplicationLevel).WithMany(p => p.ApplicationRequirements)
                .HasForeignKey(d => d.ApplicationLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Application_Requirement_Application_Levels");

            entity.HasOne(d => d.ArchivesMaster).WithMany(p => p.ApplicationRequirements)
                .HasForeignKey(d => d.ArchivesMasterId)
                .HasConstraintName("FK_Application_Requirement_Archives_master");

            entity.HasOne(d => d.Displaylink).WithMany(p => p.ApplicationRequirements)
                .HasForeignKey(d => d.DisplaylinkId)
                .HasConstraintName("FK_Application_Requirement_DisplayLink");

            entity.HasOne(d => d.SharedTable).WithMany(p => p.ApplicationRequirements)
                .HasForeignKey(d => d.SharedTableId)
                .HasConstraintName("FK_Application_Requirement_Shared_Table");

            entity.HasOne(d => d.Tools).WithMany(p => p.ApplicationRequirements)
                .HasForeignKey(d => d.ToolsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Application_Requirement_Tools");
        });

        modelBuilder.Entity<ApplicationRequirementDetail>(entity =>
        {
            entity.HasKey(e => e.ApplicationReqDetailsId);

            entity.ToTable("Application_Requirement_Details");

            entity.Property(e => e.ApplicationReqDetailsId).HasColumnName("Application_Req_Details_Id");
            entity.Property(e => e.AppReqDValue)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("App_Req_D_Value");
            entity.Property(e => e.ApplicationReqDetailsInUse).HasColumnName("Application_Req_Details_In_Use");
            entity.Property(e => e.ApplicationRequirementId).HasColumnName("Application_Requirement_Id");
            entity.Property(e => e.CrDate)
                .HasColumnType("datetime")
                .HasColumnName("Cr_Date");
            entity.Property(e => e.CrEmpId).HasColumnName("Cr_Emp_Id");
            entity.Property(e => e.UpDate)
                .HasColumnType("datetime")
                .HasColumnName("Up_Date");
            entity.Property(e => e.UpEmpId).HasColumnName("Up_Emp_Id");

            entity.HasOne(d => d.ApplicationRequirement).WithMany(p => p.ApplicationRequirementDetails)
                .HasForeignKey(d => d.ApplicationRequirementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Application_Requirement_Details_Application_Requirement");
        });

        modelBuilder.Entity<ArchivesMaster>(entity =>
        {
            entity.ToTable("Archives_master");

            entity.Property(e => e.ArchivesMasterId).HasColumnName("Archives_master_Id");
            entity.Property(e => e.ArchivesMasterActive).HasColumnName("Archives_master_Active");
            entity.Property(e => e.ArchivesMasterName)
                .HasMaxLength(50)
                .HasColumnName("Archives_master_Name");
            entity.Property(e => e.ArchivesMasterNote)
                .HasColumnType("text")
                .HasColumnName("Archives_master_Note");
            entity.Property(e => e.CrDate)
                .HasColumnType("datetime")
                .HasColumnName("Cr_Date");
            entity.Property(e => e.CrUserId)
                .HasMaxLength(128)
                .HasColumnName("Cr_UserId");
            entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");
            entity.Property(e => e.UpDate)
                .HasColumnType("datetime")
                .HasColumnName("up_Date");
            entity.Property(e => e.UpUserId)
                .HasMaxLength(128)
                .HasColumnName("Up_UserId");

            entity.HasOne(d => d.Department).WithMany(p => p.ArchivesMasters)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Archives_master_Department");
        });

        modelBuilder.Entity<AttachmentDetail>(entity =>
        {
            entity.ToTable("AttachmentDetail");

            entity.Property(e => e.CrDate).HasColumnType("datetime");
            entity.Property(e => e.CrEmpId).HasColumnName("Cr_EmpId");
            entity.Property(e => e.Size).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.Attachment).WithMany(p => p.AttachmentDetails)
                .HasForeignKey(d => d.AttachmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AttachmentDetail_AttachmentMaster");
        });

        modelBuilder.Entity<AttachmentMaster>(entity =>
        {
            entity.HasKey(e => e.AttachmentId);

            entity.ToTable("AttachmentMaster");

            entity.Property(e => e.CrDate)
                .HasColumnType("datetime")
                .HasColumnName("Cr_Date");
            entity.Property(e => e.CrEmpId).HasColumnName("Cr_EmpID");
        });

        modelBuilder.Entity<AttachmentsType>(entity =>
        {
            entity.HasKey(e => e.AttachTypeId);

            entity.ToTable("AttachmentsType");

            entity.Property(e => e.AttachTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<CheckListDetail>(entity =>
        {
            entity.HasKey(e => e.CheckListDetailsId);

            entity.ToTable("Check_List_Details");

            entity.Property(e => e.CheckListDetailsId).HasColumnName("Check_List_Details_Id");
            entity.Property(e => e.ApplicationRequirementId).HasColumnName("Application_Requirement_Id");
            entity.Property(e => e.CheckListValue).HasColumnName("Check_List_Value");
            entity.Property(e => e.RequestId).HasColumnName("Request_ID");
        });

        modelBuilder.Entity<DepManager>(entity =>
        {
            entity.ToTable("DepManager");

            entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");
            entity.Property(e => e.EmployeId).HasColumnName("Employe_Id");

            entity.HasOne(d => d.Department).WithMany(p => p.DepManagers)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DepManager_Department");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK_DEPARTMENT");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");
            entity.Property(e => e.DepartmentNameAr)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Department_Name_Ar");
            entity.Property(e => e.DepartmentNameEng)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Department_Name_Eng");
            entity.Property(e => e.DeptCreDate)
                .HasColumnType("date")
                .HasColumnName("DEPT_CRE_DATE");
            entity.Property(e => e.DeptCreUid).HasColumnName("DEPT_CRE_UID");
            entity.Property(e => e.Divisionid).HasColumnName("DIVISIONID");
            entity.Property(e => e.StatusId).HasColumnName("STATUS_ID");
        });

        modelBuilder.Entity<DisplayLink>(entity =>
        {
            entity.ToTable("DisplayLink");

            entity.Property(e => e.DisplayFunction).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.CivilRankId).HasColumnName("CivilRankID");
            entity.Property(e => e.CivilRankName).HasMaxLength(50);
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(50)
                .HasColumnName("Employee_Name");
            entity.Property(e => e.Idnumber)
                .HasMaxLength(50)
                .HasColumnName("IDNumber");
            entity.Property(e => e.MilitaryRankId).HasColumnName("MilitaryRank_ID");
            entity.Property(e => e.MilitaryRankName)
                .HasMaxLength(50)
                .HasColumnName("Military_Rank_Name");
            entity.Property(e => e.NtUser)
                .HasMaxLength(50)
                .HasColumnName("NT_User");
        });

        modelBuilder.Entity<FnApplicationLevelAssigned>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_FnApplicationLevelAssigned");

            entity.Property(e => e.ApplicationLevelAssignedId).HasColumnName("Application_Level_Assigned_Id");
            entity.Property(e => e.ApplicationLevelId).HasColumnName("Application_Level_Id");
            entity.Property(e => e.AssTo).HasMaxLength(128);
            entity.Property(e => e.AssType).HasMaxLength(128);
            entity.Property(e => e.AssginTypeId).HasColumnName("AssginTypeID");
            entity.Property(e => e.AssignedInUse).HasColumnName("Assigned_In_Use");
            entity.Property(e => e.AssignedToEmpId).HasColumnName("Assigned_To_Emp_Id");
            entity.Property(e => e.CrDate)
                .HasColumnType("datetime")
                .HasColumnName("Cr_Date");
            entity.Property(e => e.CrEmpId)
                .HasMaxLength(128)
                .HasColumnName("Cr_Emp_Id");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(128)
                .HasColumnName("Employee_Name");
            entity.Property(e => e.Idnumber)
                .HasMaxLength(128)
                .HasColumnName("IDNumber");
            entity.Property(e => e.ManagerTypeId).HasColumnName("ManagerTypeID");
            entity.Property(e => e.NtUser)
                .HasMaxLength(128)
                .HasColumnName("NT_User");
            entity.Property(e => e.UpDate)
                .HasColumnType("datetime")
                .HasColumnName("Up_Date");
            entity.Property(e => e.UpEmpId)
                .HasMaxLength(128)
                .HasColumnName("Up_Emp_Id");
        });

        modelBuilder.Entity<FnEmp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_FnEmp");

            entity.Property(e => e.CivilRankId).HasColumnName("CivilRankID");
            entity.Property(e => e.CivilRankName).HasMaxLength(50);
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(50)
                .HasColumnName("Employee_Name");
            entity.Property(e => e.Idnumber)
                .HasMaxLength(50)
                .HasColumnName("IDNumber");
            entity.Property(e => e.Ip).HasColumnName("IP");
            entity.Property(e => e.LastRequestId).HasColumnName("LastRequestID");
            entity.Property(e => e.MilitaryRankId).HasColumnName("MilitaryRank_ID");
            entity.Property(e => e.MilitaryRankName)
                .HasMaxLength(50)
                .HasColumnName("Military_Rank_Name");
            entity.Property(e => e.NtUser)
                .HasMaxLength(50)
                .HasColumnName("NT_User");
            entity.Property(e => e.SwitchIp).HasColumnName("SwitchIP");
        });

        modelBuilder.Entity<LinkCondation>(entity =>
        {
            entity.ToTable("LinkCondation");

            entity.HasIndex(e => new { e.ApplictionLinkId, e.ActionId }, "NonClusteredIndex-20240909-213043").IsUnique();

            entity.Property(e => e.LinkCondationId).HasColumnName("LinkCondationID");
            entity.Property(e => e.ActionId).HasColumnName("ActionID");
            entity.Property(e => e.ChangeActionId).HasColumnName("ChangeActionID");

            entity.HasOne(d => d.Action).WithMany(p => p.LinkCondationActions)
                .HasForeignKey(d => d.ActionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LinkCondation_Actions");

            entity.HasOne(d => d.ApplictionLink).WithMany(p => p.LinkCondations)
                .HasForeignKey(d => d.ApplictionLinkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LinkCondation_ApplicationLink");

            entity.HasOne(d => d.ChangeAction).WithMany(p => p.LinkCondationChangeActions)
                .HasForeignKey(d => d.ChangeActionId)
                .HasConstraintName("FK_LinkCondation_ActionsForChange");
        });

        modelBuilder.Entity<ManagerType>(entity =>
        {
            entity.ToTable("ManagerType");

            entity.Property(e => e.ManagerTypeId).HasColumnName("ManagerTypeID");
            entity.Property(e => e.ManagerTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("Notification");

            entity.Property(e => e.ControllerName).HasMaxLength(50);
            entity.Property(e => e.CrDate).HasColumnType("datetime");
            entity.Property(e => e.CrEmpId).HasColumnName("CrEmpID");
            entity.Property(e => e.PageName).HasMaxLength(50);

            entity.HasOne(d => d.NotificationApp).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.NotificationAppId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notification_NotificationApp");
        });

        modelBuilder.Entity<NotificationApp>(entity =>
        {
            entity.ToTable("NotificationApp");

            entity.Property(e => e.NotificationAppName).HasMaxLength(50);
        });

        modelBuilder.Entity<Notifier>(entity =>
        {
            entity.ToTable("Notifier");

            entity.Property(e => e.ReadDate).HasColumnType("datetime");

            entity.HasOne(d => d.Notification).WithMany(p => p.Notifiers)
                .HasForeignKey(d => d.NotificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notifier_Notification");
        });

        modelBuilder.Entity<RelativeType>(entity =>
        {
            entity.ToTable("RelativeType");

            entity.Property(e => e.RelativeTypeId).HasColumnName("Relative_TypeId");
            entity.Property(e => e.RelativeTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.ToTable("Request");

            entity.Property(e => e.RequestId).HasColumnName("Request_ID");
            entity.Property(e => e.ApplicationId).HasColumnName("Application_Id");
            entity.Property(e => e.AssignedFromEmpId).HasColumnName("Assigned_From_Emp_Id");
            entity.Property(e => e.ComplateDate)
                .HasColumnType("datetime")
                .HasColumnName("Complate_Date");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedUser).HasMaxLength(128);
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("End_Date");
            entity.Property(e => e.IsComplate).HasColumnName("Is_Complate");
            entity.Property(e => e.IsEnd).HasColumnName("Is_End");
            entity.Property(e => e.RequestDate)
                .HasColumnType("datetime")
                .HasColumnName("Request_Date");
            entity.Property(e => e.RequestStatusId).HasColumnName("Request_Status_Id");

            entity.HasOne(d => d.Application).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Request_Applications");

            entity.HasOne(d => d.RequestStatus).WithMany(p => p.Requests)
                .HasForeignKey(d => d.RequestStatusId)
                .HasConstraintName("FK_Request_Request_Status");
        });

        modelBuilder.Entity<RequestDetail>(entity =>
        {
            entity.HasKey(e => e.RequestDetailsId);

            entity.ToTable("Request_Details");

            entity.Property(e => e.RequestDetailsId).HasColumnName("Request_Details_Id");
            entity.Property(e => e.ApplicationRequirementId).HasColumnName("Application_Requirement_Id");
            entity.Property(e => e.RequestId).HasColumnName("Request_ID");
            entity.Property(e => e.RequestLevelId).HasColumnName("Request_Level_Id");
            entity.Property(e => e.SApplicationReqDetailsId).HasColumnName("S_Application_Req_Details_Id");
            entity.Property(e => e.SDate)
                .HasColumnType("datetime")
                .HasColumnName("S_Date");
            entity.Property(e => e.SSharedTableId).HasColumnName("S_Shared_Table_Id");
            entity.Property(e => e.SSharedTableIdValue).HasColumnName("S_Shared_Table_Id_Value");
            entity.Property(e => e.SValue)
                .HasColumnType("text")
                .HasColumnName("S_Value");

            entity.HasOne(d => d.ApplicationRequirement).WithMany(p => p.RequestDetails)
                .HasForeignKey(d => d.ApplicationRequirementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Request_Details_Application_Requirement");

            entity.HasOne(d => d.Request).WithMany(p => p.RequestDetails)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Request_Details_Request");

            entity.HasOne(d => d.RequestLevel).WithMany(p => p.RequestDetails)
                .HasForeignKey(d => d.RequestLevelId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Request_Details_Request_Level");

            entity.HasOne(d => d.SApplicationReqDetails).WithMany(p => p.RequestDetails)
                .HasForeignKey(d => d.SApplicationReqDetailsId)
                .HasConstraintName("FK_Request_Details_Application_Requirement_Details");

            entity.HasOne(d => d.SSharedTable).WithMany(p => p.RequestDetails)
                .HasForeignKey(d => d.SSharedTableId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Request_Details_Shared_Table");
        });

        modelBuilder.Entity<RequestDetailsAttach>(entity =>
        {
            entity.ToTable("Request_Details_Attach");

            entity.Property(e => e.RequestDetailsAttachId).HasColumnName("Request_Details_Attach_Id");
            entity.Property(e => e.ApplicationRequirementId).HasColumnName("Application_Requirement_Id");
            entity.Property(e => e.CrDate)
                .HasColumnType("datetime")
                .HasColumnName("Cr_Date");
            entity.Property(e => e.CrEmpId).HasColumnName("Cr_Emp_Id");
            entity.Property(e => e.RequestDetailsAttachName)
                .IsUnicode(false)
                .HasColumnName("Request_Details_Attach_Name");
            entity.Property(e => e.RequestDetailsAttachPath)
                .IsUnicode(false)
                .HasColumnName("Request_Details_Attach_Path");
            entity.Property(e => e.RequestDetailsId).HasColumnName("Request_Details_Id");
            entity.Property(e => e.RequestId).HasColumnName("Request_ID");
            entity.Property(e => e.RequestLevelId).HasColumnName("Request_Level_Id");

            entity.HasOne(d => d.ApplicationRequirement).WithMany(p => p.RequestDetailsAttaches)
                .HasForeignKey(d => d.ApplicationRequirementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Request_Details_Attach_Application_Requirement");

            entity.HasOne(d => d.RequestLevel).WithMany(p => p.RequestDetailsAttaches)
                .HasForeignKey(d => d.RequestLevelId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Request_Details_Attach_Request_Level");
        });

        modelBuilder.Entity<RequestDetailsStatus>(entity =>
        {
            entity.ToTable("Request_Details_Status");

            entity.Property(e => e.RequestDetailsStatusId)
                .ValueGeneratedNever()
                .HasColumnName("Request_Details_Status_Id");
            entity.Property(e => e.RequestDetailsStatusAr)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Request_Details_Status_Ar");
            entity.Property(e => e.RequestDetailsStatusEng)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Request_Details_Status_Eng");
        });

        modelBuilder.Entity<RequestLevel>(entity =>
        {
            entity.ToTable("Request_Level");

            entity.Property(e => e.RequestLevelId).HasColumnName("Request_Level_Id");
            entity.Property(e => e.ActionDate)
                .HasColumnType("datetime")
                .HasColumnName("Action_Date");
            entity.Property(e => e.ApplicationLevelId).HasColumnName("Application_Level_Id");
            entity.Property(e => e.AssignedDate)
                .HasColumnType("datetime")
                .HasColumnName("Assigned_Date");
            entity.Property(e => e.AssignedToEmpId).HasColumnName("Assigned_To_Emp_Id");
            entity.Property(e => e.ConversionToEmpId).HasColumnName("Conversion_To_Emp_Id");
            entity.Property(e => e.InUse).HasColumnName("In_Use");
            entity.Property(e => e.RequestDetailsStatusId).HasColumnName("Request_Details_Status_Id");
            entity.Property(e => e.RequestId).HasColumnName("Request_ID");

            entity.HasOne(d => d.ApplicationLevel).WithMany(p => p.RequestLevels)
                .HasForeignKey(d => d.ApplicationLevelId)
                .HasConstraintName("FK_Request_Level_ApplicationRequest");

            entity.HasOne(d => d.RequestDetailsStatus).WithMany(p => p.RequestLevels)
                .HasForeignKey(d => d.RequestDetailsStatusId)
                .HasConstraintName("FK_Request_Level_Request_Details_Status");

            entity.HasOne(d => d.Request).WithMany(p => p.RequestLevels)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK_Request_Level_Request");
        });

        modelBuilder.Entity<RequestLevelAssigned>(entity =>
        {
            entity.ToTable("Request_Level_Assigned");

            entity.Property(e => e.RequestLevelAssignedId).HasColumnName("Request_Level_Assigned_Id");
            entity.Property(e => e.ApplicationLevelId).HasColumnName("Application_Level_Id");
            entity.Property(e => e.AssignedToUserId).HasColumnName("Assigned_To_UserID");
            entity.Property(e => e.RequestLevelId).HasColumnName("Request_Level_Id");

            entity.HasOne(d => d.RequestLevel).WithMany(p => p.RequestLevelAssigneds)
                .HasForeignKey(d => d.RequestLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Request_Level_Assigned_Request_Level");
        });

        modelBuilder.Entity<RequestStatus>(entity =>
        {
            entity.ToTable("Request_Status");

            entity.Property(e => e.RequestStatusId).HasColumnName("Request_Status_Id");
            entity.Property(e => e.InEnd).HasColumnName("In_End");
            entity.Property(e => e.InStart).HasColumnName("In_Start");
            entity.Property(e => e.RequestStatusAr)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Request_Status_Ar");
            entity.Property(e => e.RequestStatusEng)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Request_Status_Eng");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleName).HasMaxLength(50);
            entity.Property(e => e.RoleNameAr).HasMaxLength(50);
        });

        modelBuilder.Entity<RoleUser>(entity =>
        {
            entity.ToTable("RoleUser");

            entity.Property(e => e.CrDate).HasColumnType("datetime");

            entity.HasOne(d => d.Role).WithMany(p => p.RoleUsers)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoleUser_Role");

            entity.HasOne(d => d.User).WithMany(p => p.RoleUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoleUser_UserInfo");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.ToTable("Section");

            entity.Property(e => e.SectionId).HasColumnName("Section_Id");
            entity.Property(e => e.CrDate)
                .HasColumnType("datetime")
                .HasColumnName("Cr_Date");
            entity.Property(e => e.CrUserId)
                .HasMaxLength(128)
                .HasColumnName("Cr_UserId");
            entity.Property(e => e.DeptId).HasColumnName("DEPT_ID");
            entity.Property(e => e.SectionInUse).HasColumnName("Section_In_Use");
            entity.Property(e => e.SectionNameEng)
                .HasMaxLength(50)
                .HasColumnName("Section_Name_Eng");
            entity.Property(e => e.UpDate)
                .HasColumnType("datetime")
                .HasColumnName("Up_Date");
            entity.Property(e => e.UpUserId)
                .HasMaxLength(128)
                .HasColumnName("Up_UserId");

            entity.HasOne(d => d.Dept).WithMany(p => p.Sections)
                .HasForeignKey(d => d.DeptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Section_DEPARTMENT");
        });

        modelBuilder.Entity<SharedTable>(entity =>
        {
            entity.ToTable("Shared_Table");

            entity.Property(e => e.SharedTableId).HasColumnName("Shared_Table_Id");
            entity.Property(e => e.InUse).HasColumnName("InUSe");
            entity.Property(e => e.SharedTableColumn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Shared_Table_Column");
            entity.Property(e => e.SharedTableName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Shared_Table_Name");
            entity.Property(e => e.SharedTableNameDisplayed)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Shared_Table_Name_displayed");
            entity.Property(e => e.SharedTableValue)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Shared_Table_Value");
        });

        modelBuilder.Entity<SharedTableDatum>(entity =>
        {
            entity.HasKey(e => e.DropIdTable).HasName("PK_SharedTableData");

            entity.ToTable("_SharedTableData");

            entity.Property(e => e.DropIdTable).ValueGeneratedNever();
            entity.Property(e => e.DropId)
                .HasMaxLength(50)
                .HasColumnName("Drop_Id");
            entity.Property(e => e.DropName)
                .HasMaxLength(50)
                .HasColumnName("Drop_Name");
            entity.Property(e => e.SharedTableId).HasColumnName("Shared_Table_Id");
        });

        modelBuilder.Entity<SystemInfo>(entity =>
        {
            entity.ToTable("SystemInfo");

            entity.Property(e => e.SystemInfoName).HasMaxLength(50);
        });

        modelBuilder.Entity<Tool>(entity =>
        {
            entity.HasKey(e => e.ToolsId);

            entity.Property(e => e.ToolsId).HasColumnName("Tools_Id");
            entity.Property(e => e.FromDataBase).HasColumnName("From_DataBase");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Img_Url");
            entity.Property(e => e.ToolInUse).HasColumnName("Tool_In_Use");
            entity.Property(e => e.ToolName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Tool_Name");
            entity.Property(e => e.ToolValue)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Tool_value");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("UserInfo");

            entity.Property(e => e.CrDate).HasColumnType("datetime");
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserIdentity).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
