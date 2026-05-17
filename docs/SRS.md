Software Requirements Specification (SRS)
Project: [Medical Laboratory Chain Management System (MediChain)]
Module/Subsystem: [Imaging & Radiology Scheduling]
Version: 1.0
Date: [2026-05-13]
---

## 1. Introduction
### 1.1 Purpose
* This document presents the Software Requirements Specification (SRS) for the Imaging & Radiology Scheduling System (RAD-SCH). The purpose of this document is to define the functional and non-functional requirements of the system and provide a clear reference for developers, analysts, testers, and project stakeholders.The RAD-SCH module is part of the MediChain healthcare system and is responsible for managing MRI and CT scan appointments, scheduling operations, patient preparation instructions, notification services, and automatic rescheduling processes in case of device failures.

### 1.2 Scope
* The Imaging & Radiology Scheduling System is designed to improve the management of radiology appointments and optimize the use of MRI and CT devices within healthcare facilities 1.2.1.The system will: Schedule MRI and CT scan appointments. Manage patient preparation instructions Automatically select the best available appointment Handle appointment prioritization based on urgency Send notifications to patients. Automatically reschedule appointments in case of machine failure Prevent overlapping appointments on the same device 1.2.2.The system will NOT: Perform medical diagnosis Manage payroll or human resources Manage non-radiology hospital departments Replace medical staff decision-making Store medical imaging files

### 1.3 Definitions, Acronyms, and Abbreviations
* MRI: Magnetic Resonance Imaging
* CT: Computed Tomography
* RAD-SCH: Radiology Scheduling Module
* Appointment: Scheduled radiology examination
* Preparation Instructions: Instructions given to patients before examination
* Notification: Alert sent to the patient


### 1.4 References
* 1.IEEE 830 Software Requirements Specification Standard. 2.MediChain System Documentation 3.Software Engineering Course Materials 4.UML Modeling References 5.Project Analysis Documents prepared by the RAD-SCH Team

### 1.5 Overview
* **Instruction:** Briefly explain how the rest of this SRS document is organized.

---

## 2. Overall Description
### 2.1 Product Perspective
* RAD-SCH is a specialized software system designed to manage and schedule medical radiology appointments (e.g., CT and MRI scans) within a laboratory environment. The system aims to optimize the operational efficiency of radiology equipment through intelligent scheduling. This logic incorporates several critical factors, including scan duration, clinical case priority, and available device capacity. RAD-SCH operates as an integral component of a larger Hospital Management System (HMS), interfacing seamlessly with Patient Management and Notification systems. It is engineered to minimize idle time between appointments and enhance the overall patient experience through precise coordination and automated rescheduling in the event of equipment downtime or technical failures. From a technical standpoint, the system follows a Client-Server architecture: Backend (Server-side): Responsible for processing the core scheduling logic and data management. Frontend (Client-side): Provides the user interface for data visualization, interaction, and administrative control.

*   **2.1.1 System Interfaces:The system interacts with several internal and external interfaces to ensure seamless operations and full functionality: RESTful API Interfaces:Used to facilitate secure and efficient data exchange between the Frontend (Client) and the Backend (Server). Patient Management System (PMS) Interface:Integrates with the existing hospital Patient Management System to retrieve, synchronize, and update patient records and clinical data. Notification System Interface:Responsible for triggering and sending automated notifications to patients through multiple channels, including: Email: For detailed appointment confirmations and preparation instructions. Short Message Service (SMS): For quick reminders and urgent rescheduling alerts. Scheduling Engine Interface: An internal interface that connects the system’s core logic with the specialized scheduling module, which is responsible for executing the intelligent optimization algorithms
*   **2.1.2 User Interfaces:The system provides intuitive and user-friendly interfaces tailored to different user roles: Main Dashboard: Provides a high-level overview of device statuses, upcoming appointments, and system alerts. Appointment Scheduling Interface: A dedicated module for entering examination requests and managing schedule slots. Device Management Interface: Used to manage and monitor MRI and CT equipment status (Available, Maintenance/Down, In-Use). Calendar View Interface: Offers a visual representation of scheduled appointments with Daily and Weekly viewing modes. Notification Interface: Displays logs and statuses of all messages and alerts sent to patients.
*   **2.1.3 Hardware Interfaces:The system interacts with the following hardware components indirectly (Administrative management rather than direct operational control): MRI (Magnetic Resonance Imaging) Machines CT (Computed Tomography) Scanners Note: The system does not interface with the hardware’s internal operating software; instead, it manages usage schedules based on the temporal capacity and availability of each device.
*   **2.1.4 Software Interfaces:The system is built upon a modern technology stack to ensure scalability and performance: Frontend Framework: React.js Backend Framework: Node.js or C# (.NET Core) Database Management System (DBMS): MySQL or Microsoft SQL Server Notification Services: External APIs for Email (e.g., SendGrid) and SMS (e.g., Twilio) Authentication System: Secure JWT-based (JSON Web Token) authentication mechanism.
*   **2.1.5 Communications Interfaces:Standard communication protocols are utilized to ensure secure and high-speed data exchange: HTTP / HTTPS Protocols: To secure communication between the Client and the Server. REST API Communication: For data exchange using the JSON format. Asynchronous Communication: Employed for sending notifications to prevent blocking the main system performance. Real-Time Data Synchronization: Supports immediate updates across interfaces when appointment statuses or device availabilities change
*   **2.1.6 Memory & Operational Constraints: A. Memory Constraints (Minimum Requirements): erver-Side: RAM: Minimum 8 GB (16 GB recommended for high-load environments to handle concurrent scheduling requests). Storage: 100 GB SSD (Primary focus on Database growth and logging). Client-Side (User PC):RAM: Minimum 4 GB. Web Browser: Modern browser support (Chrome 90+, Firefox 85+, or Edge) with JavaScript enabled. B. Operational Assumptions: Network Availability: The system assumes a stable internal network (Intranet) or Internet connection with a minimum bandwidth of 10 Mbps to ensure real-time synchronization between the hospital departments. Availability: Since radiology departments often work around the clock, the system is assumed to operate 24/7 with a target uptime of 99.9%. Database Scalability: It is assumed that the database will store text-based records and metadata for years, while actual high-resolution medical images (DICOM) are stored on a separate PACS server (if applicable). Concurrent Users: The system is designed to handle at least 50–100 concurrent users (receptionists, technicians, and admins) without significant latency in the scheduling engine. Backup & Recovery: Daily automated backups of the database are assumed to be performed to prevent data loss in case of hardware failure.

### 2.2 Product Functions
* The system provides the following core functionalities:
Automated and Manual Scheduling: Supports both intelligent automated slot allocation and manual booking for CT and MRI examinations.
Equipment Capacity Management: Manages radiology device workloads and ensures optimal distribution of appointments across available units.
Pre-Confirmation Instructions: Automatically dispatches specific preparation guidelines to patients before any appointment is finalized.
Automated Fault-Rescheduling: Triggers an immediate rescheduling logic to handle appointment conflicts arising from equipment downtime or technical failures.
Multi-Channel Notifications: Sends real-time updates, reminders, and change alerts to patients regarding their scheduled appointments.
Dynamic Request Prioritization: Sorts and prioritizes examination requests based on:
Scan Duration: Time required for the specific procedure.
Clinical Priority: The medical urgency of the patient's condition.
Precision Timeline Visualization: Provides a highly accurate, real-time visual timeline (Gantt-style) of device utilization and availability.

### 2.3 User Characteristics
* The system is designed for various types of users, each with distinct roles and responsibilities:
Receptionist / Scheduler: Responsible for inputting examination requests and managing the appointment booking process.
Doctor: Responsible for assessing and determining the Clinical Priority of the patient's medical condition.
Radiology Technician: Monitors equipment status and reports hardware failures or maintenance requirements.
System Administrator: Manages the entire system, oversees general configurations, and handles user access controls.
User Expertise Level: All user classes are expected to have basic proficiency in operating medical software systems; however, they are not required to have advanced technical or     
programming expertise.

### 2.4 Constraints, Assumptions, and Dependencies
* The operational success and accuracy of the system depend on several internal and external factors:
Data Accuracy & Availability: The system assumes the availability of precise and up-to-date patient records and appointment history.
External Notification Services: Dependency on third-party Email and SMS gateways to ensure the delivery of patient notifications.
Hardware Availability: The scheduling logic operates within the defined operational capacity and availability of the MRI and CT scanners.
User Input Integrity: The effectiveness of the scheduling engine relies on the accuracy of the medical data and priority levels entered by the users (Doctors and Receptionists).
Algorithmic Logic: The system’s performance is dependent on an Intelligent Scheduling Algorithm that is dynamically influenced by case priority and time constraints.
Network Connectivity: A stable and continuous network connection is required to guarantee real-time data synchronization and updates across the platform.

---

## 3. Specific Requirements (Agile Approach)
The system shall provide a scheduling interface where the receptionist can create, modify, and reschedule radiology appointments. The interface shall require the exam type, estimated duration, assigned device, and preparation instructions before an appointment can be confirmed. The system shall also expose notification events to the notification service when an appointment is created, updated, or rescheduled.
### 3.1 External Interface Requirements
* 3.1.1 UI-01: Smart Scheduling DashboardDescription: A consolidated calendar view for radiology department staff displaying daily/weekly slots for CT and MRI machines.Layout Requirements:A sidebar displaying the automated waiting queue prioritized by the system algorithm.Visual indicators (color-coded) for slot status: Available (Green), Booked & Confirmed (Blue), Booked but Pending Preparation Instructions (Yellow), Device Out-of-Service (Red).A "Re-schedule All" button visible only to admins when a machine status changes to "Down".UI-02: Patient Appointment & Preparation FormLayout Requirements: A form to create/confirm appointments. It must contain a mandatory checklist or text area for "Preparation Instructions" (e.g., fasting requirements for CT). The "Confirm Booking" button remains disabled ($disabled=true$) until the preparation instructions are filled or selected.
* 3.1.2 Software & API Interfaces
  A. Appointment Creation & Auto-Scheduling API:
Endpoint: POST /api/v1/appointments/schedule-auto
Data Format: JSON
  -Logic (Hybrid Context): The system processing this API will execute the sorting algorithm based on: $Duration + FIFO + Urgency$. It returns the best recommended slot.
  -Response (Success - 200 OK): Returns recommended slotId, machineId, and sets status to Pending_Instructions.
  B. Booking Confirmation & Notification APIEndpoint: PUT /api/v1/appointments/{appointmentId}/confirmData.
  Format: JSON ,Validation Rule: If preparationInstructions field is null or empty, the API returns 400 Bad Request (Validation Failed).
  * 3.1.3 Hardware Interfaces:
    HI-01: Radiology Equipment Status Interface (IoT/DICOM Gateway)
Description: The system listens to status heartbeats from the CT/MRI machinery or the hospital's central maintenance system.
Data Format: Continuous stream via WebSockets or Webhooks.
Trigger Event (Device Failure):
When a payload receives "deviceStatus": "OFFLINE_FAULT", the system automatically triggers the Bulk Fault-Rescheduling Service.
Data Action: Extracts all appointmentIds linked to that machineId for future slots, recalculates new slots for them in other functional machines (or shifts them), and pushes payload payloads to the Notification Service Queue (SMS/Email API) to alert patients.

### 3.2 System Features & User Stories
#### 3.2.1 Feature: Appointment Creation
*   **Description:** Enabling the receptionist to create an X-ray appointment for the patient.
*   **Priority:** High.
*   **User Stories:**
    *  Story 1:As a receptionist, I want to create a radiology appointment for a patient so that the patient can be scheduled for CT or MRI.
        * *Acceptance Criteria:* Selecting the type of examination is mandatory.
                                 Specifying the examination duration is mandatory.
                                  Selecting the equipment is mandatory.
                                 The appointment cannot be saved without patient information.
                                 The appointment cannot be confirmed if preparation instructions are missing.
        * *GitHub Issue:* [ ]
   *   Feature:
*   **Description:** 
*   **Priority:** High.
*   **User Stories:**
    *  Story 1:
        * *Acceptance Criteria:* Selecting the type of examination is mandatory.
                                 Specifying the examination duration is mandatory.
                                  Selecting the equipment is mandatory.
                                 The appointment cannot be saved without patient information.
                                 The appointment cannot be confirmed if preparation instructions are missing.
        * *GitHub Issue:* [ ]
      *   Feature:
*   **Description:** 
*   **Priority:** High.
*   **User Stories:**
    *  Story 1:
        * *Acceptance Criteria:* Selecting the type of examination is mandatory.
                                 Specifying the examination duration is mandatory.
                                  Selecting the equipment is mandatory.
                                 The appointment cannot be saved without patient information.
                                 The appointment cannot be confirmed if preparation instructions are missing.
        * *GitHub Issue:* [ ]
         *   Feature:
*   **Description:** 
*   **Priority:** High.
*   **User Stories:**
    *  Story 1:
        * *Acceptance Criteria:* Selecting the type of examination is mandatory.
                                 Specifying the examination duration is mandatory.
                                  Selecting the equipment is mandatory.
                                 The appointment cannot be saved without patient information.
                                 The appointment cannot be confirmed if preparation instructions are missing.
        * *GitHub Issue:* [ ]
         *   Feature:
*   **Description:** 
*   **Priority:** High.
*   **User Stories:**
    *  Story 1:
        * *Acceptance Criteria:* Selecting the type of examination is mandatory.
                                 Specifying the examination duration is mandatory.
                                  Selecting the equipment is mandatory.
                                 The appointment cannot be saved without patient information.
                                 The appointment cannot be confirmed if preparation instructions are missing.
        * *GitHub Issue:* [ ]

*   [Repeat the structure above for all module features].

### 3.3 Performance Requirements
* **Instruction:** Specify quantitative limits. (e.g., "The module must return query results in under 2 seconds for up to 50 concurrent users").

### 3.4 Logical Database Requirements
* **Instruction:** Describe the data entities managed by your module. If you are using a shared database, specify which tables your team is responsible for. (Include ERD models in the Appendix).

### 3.5 Software System Attributes
* **Instruction:** Define the Non-Functional Requirements (NFRs) for your module:
  * **Reliability:** [Acceptable failure rates].
  * **Security:** [Authentication methods, data encryption protocols].
  * **Maintainability & Portability:** [Coding standards, documentation rules].

---

## 4. Appendices
### Appendix A: Glossary & Models
* **Instruction:** Include any Data Flow Diagrams (DFDs), Entity-Relationship Diagrams (ERDs), or detailed UI Mockups here.

### Appendix B: GitHub Traceability Checklist
* **Instruction for Team Members:** Before submitting this SRS, ensure that:
  * [ ] Every User Story in Section 3.2 has a corresponding GitHub Issue.
  * [ ] Every GitHub Issue has an appropriate label (e.g., `enhancement`, `requirement`).
  * [ ] Pull Requests reference the Issue IDs (e.g., `Closes #12`). 
