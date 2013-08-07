if exists(select * from sysdatabases where name='OnLineExam')
  drop database OnLineExam
create database OnLineExam
go
use OnLineExam
go
--此表用来存储用户的基本信息
create table UserInfo
(
	UserID Varchar(20) primary key,--登录名
	UserName Varchar(50) not null,--用户姓名
	UserPwd varchar(50) not null,--密码
	RoleId int not null,--角色
	ID int--帐号ID
)
select*from	UserInfo
insert UserInfo values('admin','李四','123',3,2)
insert UserInfo values('hero','张三','123',1,1)
insert UserInfo values('tea','王五','123',2,3)
create table UserDetails
(
	ID int primary key,
	userId Varchar(20) foreign key (userId) references UserInfo(UserId) on delete cascade
)
--此表用来存储用户的角色和权限信息
create table Role
(
	RoleID Int primary key,--角色编号
	RoleName Varchar(50) not null,--角色名称
	HasDuty_DepartmentManage varchar(50),--部门管理
	HasDuty_userManage bit,--管理用户权限
	HasDuty_Role bit,--管理角色权限
	HasDuty_userScore bit,--管理用户成绩权限
	HasDuty_courseManage bit,--管理课程权限
	HasDuty_paperSetup bit,--试卷设置权限
	HasDuty_paperLists bit,--管理试卷权限
	HasDuty_userPaperList bit,--试卷评阅
	HasDuty_QuestionManage bit--管理试题权限
)
insert Role values(1,'student','',0,0,0,0,0,0,0,0)
insert Role values(2,'teacher','',0,0,0,0,0,0,0,0)
insert Role values(3,'admin','',1,1,1,1,1,1,1,1)
select RoleID, CONVERT(int,HasDuty_userManage),CONVERT(int,HasDuty_Role),CONVERT(int,HasDuty_userScore),CONVERT(int,HasDuty_paperSetup),CONVERT(int,HasDuty_paperLists),CONVERT(int,HasDuty_userPaperList),CONVERT(int,HasDuty_QuestionManage) from Role
select*from Role 
--此表用来存储考试课程信息
create table Course
(
	courseID int primary key,--编号
	courseName Varchar(200) not null--课程名
)

insert Course values(1,'语文')
insert Course values(2,'数学')
--此表用来存储试卷信息信息 
create table Paper
(
	PaperID int primary key,--试卷编号
	courseID int not null,--课程编号
	PaperName varchar(200),--试卷名
	PaperState bit,--试卷状态
	ExamTime Varchar(20) not null--考试时间
)
select courseName,PaperName,PaperState from Paper left join Course on Paper.courseID=Course.courseID
insert Paper values(1,1,'语文A',0,'2010-07-01')
insert Paper values(2,1,'语文B',0,'2010-07-01')

--此表用来存储试卷详细信息 
create table PaperDetail
(
	ID int primary key,--试卷编号
	PaperID int foreign key (PaperID) references Paper(PaperID) not null,--试卷编号
	type varchar(50) ,--题目类型
	titleID int not null,--试卷标题
	Mark int not null,--每题分值
	WriteTime int not null--做题时间
) 
--此表用来存储 用户成绩信息
create table score
(
	ID int primary key,--编号
	PaperID int not null,--试卷编号
	userID varchar(50) not null,--用户编号
	Score float not null,--试卷成绩
	examTime Varchar(20),--考试时间
	JudgeTime datetime--批阅时间
) 
select UserInfo.UserID,UserName,PaperID,Score,examTime,JudgeTime from UserInfo right join score on UserInfo.UserID=score.userID where 1=1 and PaperID=1
--此表用来存储用户答题答案信息
create table UserAnswer
(
	ID int primary key,--编号
	PaperID int not null,--试卷编号
	userID varchar(50) not null,--用户编号
	Type Varchar(50) not null,--题目类型
	examTime Varchar(20) not null,--考试时间
	TitleID int not null,--标题
	Mark int not null,--分值
	answer Varchar(1000) not null--答案
)
select SUM(Mark) from UserAnswer left join judgeProblem on UserAnswer.TitleID=judgeProblem.ID where UserAnswer.answer=CONVERT(varchar(1000) ,judgeProblem.answer)
select PaperDetail.*,courseID,Title,answer from PaperDetail left join questionProblem on PaperDetail.TitleID=questionProblem.ID 
select distinct PaperName,UserAnswer.examTime from UserAnswer left join Paper on UserAnswer.PaperID=Paper.PaperID
insert UserAnswer values('1','1','hero','judgeProblem','2010-07-01','1','2','1')
insert UserAnswer values('2','1','hero','asssd','2010-07-01','1','2','asdsa')
select distinct RANK()over(order by UserName) as ID,  UserName,examTime from UserAnswer inner join UserInfo on UserInfo.UserID=UserAnswer.userID
select identity(int,1,1) as ID,Title,UserAnswer.answer as useranswer,questionProblem.answer,CAST('' as int) score into a from UserAnswer left join questionProblem on UserAnswer.TitleID=questionProblem.ID 
select SUM(score) from a
drop table a
--此表用来存储单选题信息
create table singleProblem
(
	ID int primary key,--编号
	courseID int foreign key(courseID) references Course(courseID) not null,--课程编号
	title varchar(1000) not null,--题目
	answerA Varchar(500) not null,--选项A
	answerB Varchar(500) not null,--选项B
	answerC Varchar(500) not null,--选项C
	answerD Varchar(500) not null,--选项D
	answer Varchar(2) not null--正确答案
) 
create table multiProblem
(
	ID int primary key,--编号
	courseID int foreign key(courseID) references Course(courseID) not null,--课程编号
	title varchar(1000) not null,--题目
	answerA Varchar(500) not null,--选项A
	answerB Varchar(500) not null,--选项B
	answerC Varchar(500) not null,--选项C
	answerD Varchar(500) not null,--选项D
	answer Varchar(50) not null--正确答案
) 
--此表用来存储判断题信息
create table judgeProblem
(
	ID int primary key,--编号
	courseID int foreign key(courseID) references Course(courseID) not null,--课程编号
	title varchar(1000) not null,--题目
	answer Bit not null--正确答案
)
select *from judgeProblem
--此表用来存储填空题信息
create table fillBlankProblem
(
	ID int primary key,--编号
	courseID int foreign key(courseID) references Course(courseID) not null,--课程编号
	FrontTitle varchar(500) not null,--空格之前的题目
	backTitle Varchar(500) not null,--空格之后的题目
	answer Varchar(200) not null--正确答案
)
--此表用来存储 问答题信息
create table questionProblem
(
	ID int primary key,--编号
	courseID int foreign key(courseID) references Course(courseID) not null,--课程编号
	Title varchar(1000) not null,--题目
	answer Varchar(1000) not null--正确答案
)

create proc proc_getUser
	@userID varchar(20),
	@userPwd varchar(50)
as
	if(exists(select*from UserInfo where UserID=@userID and UserPwd=@userPwd))
	return 1
	else
	return 1
go
select top 3 *from UserInfo order by NEWID()