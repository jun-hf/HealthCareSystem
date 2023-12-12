# HealthCareSystem ⚕️
- A healthcare system that keeps track of large data of patient information allows the patients to make appointments with the system. .
- You can also keep track of the patients medical history
- Build with C# 

## How to use
Create a new healthcare system:
```
var healthcareSystem = new HealthcareSystem();
```
Create a new patient through the healthcare system
```
var josephy = healthcareSystem.AddPatient("Josephy", new DateTime(2000, 07, 1), Gender.Male);
```
Add medical record of the added patient 
```
healthcareSystem.AddMedicalRecord(josephy.PatientId, "Allergic to eggs");
```
Book an appointment for the patient 
```
healthcareSystem.ScheduleAppointment(josephy.PatientId, DateTime.Now.AddDays(5), "Health checkup");
```
