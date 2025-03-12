export interface UserDto {
  id: string;
  email: string;
  displayName: string;
  location?: string;
  website?: string;
  githubUsername?: string;
  timeZone?: string
  dateJoined: Date;
}
