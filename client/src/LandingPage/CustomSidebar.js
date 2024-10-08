import React from 'react';
import { Sidebar as FlowbiteSidebar, TextInput, Label, Textarea, Button } from "flowbite-react";
import { HiMail, HiInformationCircle, HiLogin, HiSearch, HiPaperClip, HiX } from "react-icons/hi";
import { Link } from "react-router-dom"; 
import './LandingStyle.css'; 

function CustomSidebar({ showContactForm, onContactFormToggle, onClose }) {
  return (
    <FlowbiteSidebar aria-label="Sidebar" className="sidebar">
      <div className="sidebar-header">
        <div className="flex-grow"></div>
        <button onClick={onClose} className="sidebar-button">
          <HiX className="text-black text-2xl" />
        </button>
      </div>
      <div className="flex flex-col justify-between py-2">
        <form className="pb-3 md:hidden">
          <TextInput icon={HiSearch} type="search" placeholder="Search" required size={32} />
        </form>
        <FlowbiteSidebar.Items>
          <FlowbiteSidebar.ItemGroup>
          <FlowbiteSidebar.Item>
              <Link to="/login" className="flex items-center">
                <HiLogin className="mr-2" />
                Sign in
              </Link>
            </FlowbiteSidebar.Item>
            <FlowbiteSidebar.Item href="https://github.com/themesberg/flowbite-react/issues" icon={HiInformationCircle}>
              Help
            </FlowbiteSidebar.Item>
            <FlowbiteSidebar.Item href="#" icon={HiMail} onClick={onContactFormToggle}>
              Contact Us
            </FlowbiteSidebar.Item>
          </FlowbiteSidebar.ItemGroup>
        </FlowbiteSidebar.Items>

        {showContactForm && (
          <form action="#" className="my-4 mx-4">
            <div className="mb-6 mt-3">
              <Label htmlFor="email" className="mb-2 block">Your email</Label>
              <TextInput id="email" name="email" placeholder="name@company.com" type="email" />
            </div>
            <div className="mb-6">
              <Label htmlFor="subject" className="mb-2 block">Subject</Label>
              <TextInput id="subject" name="subject" placeholder="Let us know how we can help you" />
            </div>
            <div className="mb-6">
              <Label htmlFor="message" className="mb-2 block">Your message</Label>
              <Textarea id="message" name="message" placeholder="Your message..." rows={4} />
            </div>
            <div className="mb-6 flex items-center">
              <input 
                type="file" 
                id="file" 
                name="file" 
                accept="image/*,application/pdf" 
                className="hidden" 
              />
              <label htmlFor="file">
                <Button className="">
                  <HiPaperClip className="mr-2" /> Attach a file
                </Button>
              </label>
            </div>
            <div>
              <Button type="submit" className="w-full">Send message</Button>
            </div>
          </form>
        )}
      </div>
    </FlowbiteSidebar>
  );
}

export default CustomSidebar;