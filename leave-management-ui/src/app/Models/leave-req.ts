export interface LeaveRequest {
  id?: number;
  associateId: string;
  leaveDate: string; 
  absenceType: string; // V, S, P
}