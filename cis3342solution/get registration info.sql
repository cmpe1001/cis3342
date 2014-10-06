select Students.StudentID, Students.Name, CourseRegistration.CRN, Course.CourseTitle from Students
left join CourseRegistration on CourseRegistration.StudentID = Students.StudentID
left join Course on CourseRegistration.CRN = Course.CRN
where
	Name is not null
and
	CourseTitle is not null