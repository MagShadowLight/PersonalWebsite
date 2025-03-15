export interface Feedback {
  FeedbackId: number;

  FeedbackName: string;

  email: string;

  comment: string;

  responseRequired: boolean;

  isResolved: boolean;
}
