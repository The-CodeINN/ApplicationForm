import * as z from 'zod';

// Enums for QuestionGroup and QuestionType
const questionGroups = ['PersonalInformation', 'CustomQuestions'] as const;
const questionTypes = [
  'Text',
  'Paragraph',
  'Date',
  'YesOrNo',
  'Number',
  'Dropdown',
  'MultipleChoice',
] as const;

export type QuestionGroup = (typeof questionGroups)[number];
export type QuestionType = (typeof questionTypes)[number];

// schemas
const createQuestionOptionSchema = z.object({
  title: z.string(),
});

const createFormQuestionSchema = z.object({
  title: z.string(),
  mandatory: z.boolean().optional(),
  internal: z.boolean(),
  hidden: z.boolean(),
  enableOthers: z.boolean(),
  maxChoiceAllowed: z.number().optional(),
  type: z.enum(questionTypes),
  group: z.enum(questionGroups),
  options: z.array(createQuestionOptionSchema),
});

export const createProgramApplicationFormSchema = z.object({
  title: z.string(),
  description: z.string(),
  questions: z.array(createFormQuestionSchema),
});

//Types derived from the schemas
export type CreateQuestionOptionRequestValues = z.infer<
  typeof createQuestionOptionSchema
>;
export type CreateFormQuestionRequestValues = z.infer<
  typeof createFormQuestionSchema
>;
export type CreateProgramApplicationFormRequestValues = z.infer<
  typeof createProgramApplicationFormSchema
>;
