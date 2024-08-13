import axios, { AxiosResponse } from 'axios';
import { appConfig } from '@/lib/config';

export type QuestionGroup = 'PersonalInformation' | 'CustomQuestions';

export type QuestionType =
  | 'Text'
  | 'Paragraph'
  | 'Date'
  | 'YesOrNo'
  | 'Number'
  | 'Dropdown'
  | 'MultipleChoice';

export interface CreateQuestionOptionRequestDto {
  title: string;
}

export interface CreateFormQuestionRequestDto {
  title: string;
  mandatory: boolean;
  internal: boolean;
  hidden: boolean;
  enableOthers: boolean;
  maxChoiceAllowed?: number;
  type: QuestionType;
  group: QuestionGroup;
  options: CreateQuestionOptionRequestDto[];
}

export interface CreateProgramApplicationFormRequestDto {
  title: string;
  description: string;
  questions: CreateFormQuestionRequestDto[];
}

class EmployerService {
  static createForm = async (
    formData: CreateProgramApplicationFormRequestDto
  ): Promise<AxiosResponse> => {
    return axios.post(`${appConfig.backendUrl}/employer/create-form`, formData);
  };
}

export default EmployerService;
