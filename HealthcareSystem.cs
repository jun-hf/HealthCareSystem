using System;
using System.Collections.Generic;

public enum Gender
{
    Female,
    Male,
    Other
}

class Patient
{
    public Guid PatientId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender PatientGender { get; set; }
    public List<string> MedicalRecord { get; set; } = new List<string>();
}

class Appointment
{
    public Patient Patient { get; set; }
    public Guid AppointmentId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string AppointmentDescription { get; set; }
}

class HealthcareSystem
{
    private List<Patient> patientsList = new List<Patient>();
    private List<Appointment> appointmentsList = new List<Appointment>();

    public Patient AddPatient(string name, DateTime dateOfBirth, Gender gender)
    {
        var newPatient = new Patient
        {
            PatientId = Guid.NewGuid(),
            Name = name,
            DateOfBirth = dateOfBirth,
            PatientGender = gender,
        };
        patientsList.Add(newPatient);
        Console.WriteLine("Patient added successfully.");
        return newPatient;
    }

    public void AddMedicalRecord(Guid patientId, string medicalRecord)
    {
        var patient = patientsList.Find(p => p.PatientId == patientId);
        if (patient != null)
        {
            patient.MedicalRecord.Add(medicalRecord);
            Console.WriteLine("Medical history added successfully.");
        }
        else
        {
            Console.WriteLine("Patient not found.");
        }
    }

    public Appointment ScheduleAppointment(Guid patientId, DateTime appointmentDate, string description)
    {
        var patient = patientsList.Find(p => p.PatientId == patientId);
        if (patient != null)
        {
            var newAppointment = new Appointment
            {
                Patient = patient,
                AppointmentId = Guid.NewGuid(),
                AppointmentDate = appointmentDate,
                AppointmentDescription = description
            };
            appointmentsList.Add(newAppointment);
            Console.WriteLine("Appointment scheduled successfully :)");
            return newAppointment;
        }
        else
        {
            Console.WriteLine("Patient not found.");
            return null; 
        }
    }
}

class Program
{
    static void Main()
    {
        var healthcareSystem = new HealthcareSystem();

        var josephy = healthcareSystem.AddPatient("Josephy", new DateTime(2000, 07, 1), Gender.Male);
        healthcareSystem.AddMedicalRecord(josephy.PatientId, "Allergic to eggs");
        healthcareSystem.ScheduleAppointment(josephy.PatientId, DateTime.Now.AddDays(5), "Health checkup");
    }
}
