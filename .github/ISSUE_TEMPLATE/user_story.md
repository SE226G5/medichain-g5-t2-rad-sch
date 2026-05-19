## [REQ-ID] : User Story Title
**Related SRS Section:** [e.g., Section 3.2.1]

### 1. User Story
Story 1:As a receptionist, I want to create a radiology appointment for a patient so that the patient can be scheduled for CT or MRI.
Story 2:As a system, I want to automatically select the best available appointment slot for a device so that scheduling is optimized according to exam duration, request order, and case priority.
Story 3:As a Administrater Staff(receptionist), I want to add preparation instructions when creating an appointment so that the patient receives the required instructions before the exam.
Story 4:As a notification system, I want to receive appointment events so that I can notify the patient about the booking status.
Story 5:As a system, I want to reschedule all appointments affected by device downtime so that patients are assigned new available slots automatically.
Story 6:As a receptionist, I want to view the current status of each appointment so that I can manage patient scheduling effectively.

### 2. Acceptance Criteria
- [ ] Criterion 1 (Selecting the type of examination is mandatory. Specifying the examination duration is mandatory. Selecting the equipment is mandatory. The appointment cannot be saved without patient information. The appointment cannot be confirmed if preparation instructions are missing.)
- [ ] Criterion 2 ( The system does not select a time that exceeds the device's capacity. The system takes into account the duration of each scan. Higher priority cases are prioritized in case of conflict. When priorities are equal, the system relies on the order of requests.)
- [ ] Criterion 3 (Preparation instructions field is mandatory before confirmation. The status cannot be changed to Confirmed without instructions. Instructions are saved with the appointment. Instructions are sent to the notification system after saving.)
- [ ] Criterion 4  (Send notification when appointment is created Send notification when appointment is modified Send notification when rescheduled Submission status log: Success / Failed)
- [ ] Criterion 5 (Identify all appointments associated with the malfunctioning machine. Reschedule them to suitable new dates. Maintain priority order as much as possible. Notify the patient and receptionist of the change. Record the reason for rescheduling.)
- [ ] Criterion 6 (Clearly display the current status. Update the status in real time or after any modification. Save the change log.)


### 3. Technical Notes (Optional)
- Integration point: [e.g., Subsystem B API]
- Database table: [<img width="1280" height="819" alt="photo_2026-05-12_21-12-10" src="https://github.com/user-attachments/assets/1c88788d-9b7e-408c-b9ed-2260968bcdd4" />
]

### 4. Definition of Done (DoD)
- [ ] Code follows project standards.
- [ ] Unit tests passed.
- [ ] Documentation updated in SRS.
