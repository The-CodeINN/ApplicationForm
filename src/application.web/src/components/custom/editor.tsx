import { useEditor, EditorContent, type Editor } from '@tiptap/react';
import StarterKit from '@tiptap/starter-kit';
import Placeholder from '@tiptap/extension-placeholder';
import Underline from '@tiptap/extension-underline';
import Link from '@tiptap/extension-link';
import Image from '@tiptap/extension-image';
import { GoBold } from 'react-icons/go';
import {
  MdOutlineFormatListBulleted,
  MdOutlineFormatListNumbered,
  MdFormatUnderlined,
  MdOutlineInsertLink,
} from 'react-icons/md';
import { FaStrikethrough, FaItalic } from 'react-icons/fa6';
import { BiImage } from 'react-icons/bi';

import { Toggle } from '../ui/toggle';
import { Separator } from '../ui/separator';
import { useRef } from 'react';

const RichTextEditor = () => {
  const fileInputRef = useRef<HTMLInputElement | null>(null);

  const editor = useEditor({
    editorProps: {
      attributes: {
        class:
          'min-h-[80px] max-h-[180px] w-full rounded-md rounded-br-none rounded-bl-none bg-transparent px-3 py-2 border-b-0 text-sm ring-offset-background placeholder:text-muted-foreground focus-visible:outline-none disabled:cursor-not-allowed disabled:opacity-50 overflow-auto',
      },
    },
    extensions: [
      StarterKit.configure({
        orderedList: {
          HTMLAttributes: {
            class: 'list-decimal pl-4',
          },
        },
        bulletList: {
          HTMLAttributes: {
            class: 'list-disc pl-4',
          },
        },
      }),
      Underline.configure({
        HTMLAttributes: {
          class: 'underline',
        },
      }),
      Placeholder.configure({
        placeholder:
          'You can provide all information about the program here. Please make sure to set the expectation and keep it clear',
      }),
      Link.configure({
        openOnClick: false,
      }),
      Image,
    ],
    content: '',
  });

  const addImage = () => {
    if (fileInputRef.current) {
      fileInputRef.current.click();
    }
  };

  const handleImageUpload = (event: React.ChangeEvent<HTMLInputElement>) => {
    const file = event.target.files?.[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = () => {
        const url = reader.result as string;
        editor?.chain().focus().setImage({ src: url }).run();
      };
      reader.readAsDataURL(file);
    }
  };

  return (
    <div className='border-[1.5px] p-3 rounded-md border-black'>
      {editor ? (
        <RichTextEditorToolbar editor={editor} addImage={addImage} />
      ) : null}
      <EditorContent editor={editor} />
      <input
        type='file'
        accept='image/*'
        ref={fileInputRef}
        style={{ display: 'none' }}
        onChange={handleImageUpload}
      />
    </div>
  );
};

const RichTextEditorToolbar = ({
  editor,
  addImage,
}: {
  editor: Editor;
  addImage: () => void;
}) => {
  const setLink = () => {
    const previousUrl = editor.getAttributes('link').href;
    const url = window.prompt('Enter the link URL', previousUrl);

    if (url === null) {
      return;
    }

    if (url === '') {
      editor.chain().focus().extendMarkRange('link').unsetLink().run();
      return;
    }

    editor.chain().focus().extendMarkRange('link').setLink({ href: url }).run();
  };

  return (
    <div className='bg-transparent rounded-br-md rounded-bl-md p-1 flex flex-row items-center gap-1 flex-wrap'>
      <Toggle
        size='sm'
        pressed={editor.isActive('bold')}
        onPressedChange={() => editor.chain().focus().toggleBold().run()}
      >
        <GoBold className='h-4 w-4 ' />
      </Toggle>
      <Toggle
        size='sm'
        pressed={editor.isActive('underline')}
        onPressedChange={() => editor.chain().focus().toggleUnderline().run()}
      >
        <MdFormatUnderlined className='h-5 w-5' />
      </Toggle>
      <Toggle
        size='sm'
        pressed={editor.isActive('italic')}
        onPressedChange={() => editor.chain().focus().toggleItalic().run()}
      >
        <FaItalic className='h-4 w-4' />
      </Toggle>
      <Toggle
        size='sm'
        pressed={editor.isActive('orderedList')}
        onPressedChange={() => editor.chain().focus().toggleOrderedList().run()}
      >
        <MdOutlineFormatListNumbered className='h-4 w-4' />
      </Toggle>
      <Separator orientation='vertical' className='w-[1px] h-8' />
      <Toggle
        size='sm'
        pressed={editor.isActive('bulletList')}
        onPressedChange={() => editor.chain().focus().toggleBulletList().run()}
      >
        <MdOutlineFormatListBulleted className='h-4 w-4' />
      </Toggle>
      <Toggle
        size='sm'
        pressed={editor.isActive('strike')}
        onPressedChange={() => editor.chain().focus().toggleStrike().run()}
      >
        <FaStrikethrough className='h-4 w-4' />
      </Toggle>
      <Separator orientation='vertical' className='w-[1px] h-8' />
      <Toggle size='sm' onPressedChange={setLink}>
        <MdOutlineInsertLink className='h-4 w-4' />
      </Toggle>
      <Toggle size='sm' onPressedChange={addImage}>
        <BiImage className='h-4 w-4' />
      </Toggle>
    </div>
  );
};

export default RichTextEditor;
