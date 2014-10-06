select CourseRegistration.CRN
from Students
	left join CourseRegistration on CourseRegistration.StudentID = Students.StudentID
	left join Course on CourseRegistration.CRN = Course.CRN
where Students.StudentID='23' and CourseTitle is not null

select * from Course where CRN != 