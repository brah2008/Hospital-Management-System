CREATE TABLE Patients (
    PatientId INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    -- Other columns...
);
CREATE TABLE Doctors (
    DoctorId INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    -- Other columns...
);
CREATE TABLE Appointments (
    AppointmentId INT PRIMARY KEY,
    AppointmentDate DATETIME,
    -- Other columns...
    PatientId INT,
    DoctorId INT,
    FOREIGN KEY (PatientId) REFERENCES Patients(PatientId),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId)
);
