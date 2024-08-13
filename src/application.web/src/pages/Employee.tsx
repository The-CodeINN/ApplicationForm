import AddQuestionDropdown from '@/components/custom/addQuestionDropdown';
import RichTextEditor from '@/components/custom/editor';
import InfoCard from '@/components/custom/infoCard';
import ProgramTitleInput from '@/components/custom/programTitleInput';
import QuestionAccordionItem from '@/components/custom/questionAccordionItem';
import QuestionCard from '@/components/custom/questionCard';
import {
  DropDownTemplate,
  OtherQuestionTemplate,
} from '@/components/custom/questionTemplate';
import { Accordion } from '@/components/ui/accordion';
import { Button } from '@/components/ui/button';
import { Form } from '@/components/ui/form';
import {
  CreateProgramApplicationFormRequestValues,
  createProgramApplicationFormSchema,
} from '@/lib/formSchema';
import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import useEmployer from '@/hooks/useEmployer';

const Employee = () => {
  const questions = [
    {
      title: 'First Name',
      mandatory: true,
    },
    {
      title: 'Last Name',
      mandatory: true,
    },
    {
      title: 'Email',
      mandatory: true,
    },
    {
      title: 'Phone (without dial code)',
    },
    {
      title: 'Nationality',
    },
    {
      title: 'Current Residence',
    },
    {
      title: 'ID Number',
    },
    {
      title: 'Date of Birth',
    },
    {
      title: 'Gender',
    },
  ];

  const accordionItems = [
    {
      id: 'paragraph',
      value: 'paragraph',
      label: 'Paragraph',
      description: 'Please tell me about yourself in less than 500 words',
      content: <OtherQuestionTemplate />,
    },
    {
      id: 'dropdown',
      value: 'dropdown',
      label: 'Dropdown',
      description: 'Please select your preferred programming language',
      content: <DropDownTemplate />,
    },
    {
      id: 'multipleChoice',
      value: 'multipleChoice',
      label: 'Multiple Choice',
      description: 'Please select your preferred programming language',
      content: <DropDownTemplate isMultipleChoice />,
    },
  ];

  const form = useForm<CreateProgramApplicationFormRequestValues>({
    resolver: zodResolver(createProgramApplicationFormSchema),
    defaultValues: {
      title: '',
      description: '',
      questions: [],
    },
  });

  const { createFormMutation } = useEmployer();

  const onSubmit = form.handleSubmit((data) => {
    console.log(data);
    createFormMutation.mutate(data);
  });

  return (
    <Form {...form}>
      <form onSubmit={onSubmit} className='flex flex-col gap-4 max-w-lg'>
        <ProgramTitleInput
          label='Program Title'
          placeholder='Summer Internship Program'
        />
        <div className='flex flex-col space-y-4'>
          <ProgramTitleInput label='Program Description' />
          <RichTextEditor />
        </div>
        <InfoCard title='Personal Information'>
          <div className='flex flex-col gap-6'>
            {questions.map((q, i) => (
              <QuestionCard
                key={i}
                title={q.title}
                mandatory={q.mandatory}
                isLast={i === questions.length - 1}
              />
            ))}
          </div>
          <AddQuestionDropdown />
        </InfoCard>
        <InfoCard title='Add Custom Questions'>
          <Accordion className='' type='single' collapsible>
            {accordionItems.map((item) => (
              <QuestionAccordionItem
                key={item.id}
                id={item.id}
                value={item.value}
                label={item.label}
                description={item.description}
                content={item.content}
              />
            ))}
          </Accordion>
        </InfoCard>
        <div className='flex justify-end w-full'>
          <div className='w-[60%]'>
            <Button className='bg-[#21B592]/90 w-full py-6 hover:bg-[#21B592]'>
              Create &nbsp;
              <span className='hidden md:flex'> program and application</span>
            </Button>
          </div>
        </div>
      </form>
    </Form>
  );
};

export default Employee;
