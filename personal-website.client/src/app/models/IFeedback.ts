export interface Feedback {
  id: number;

  feedbackName: string;

  email: string;

  feedbackComment: string;

  neededResponse: boolean;

  isResolved: boolean;
}
