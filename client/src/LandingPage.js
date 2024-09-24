// import React, { useState } from 'react';
// import './LandingPage.css';
// import { FaRegComments } from 'react-icons/fa'; 

// function LandingPage() {

//   const [formData, setFormData] = useState({
//     fullName: '',
//     email: '',
//     resume: null,
//   });

//   const handleChange = (e) => {
//     const { name, value, files } = e.target;
//     if (name === 'resume') {
//       setFormData({
//         ...formData,
//         resume: files[0],
//       });
//     } else {
//       setFormData({
//         ...formData,
//         [name]: value,
//       });
//     }
//   };

//   return (
//     <div className="landing-page">
      
//       <header className="header">
//         <h1>Express Tax</h1>
//         <h2>Time is precious.</h2>
//         <button className="order-btn">Book a taxi now</button>
//       </header>

//       <section className="features">
//         <ul>
//           <li>Taxis available within minutes</li>
//           <li>Professional and experienced drivers</li>
//           <li>24/6 service</li>
//           <li>Real time taxi tracking</li>
//         </ul>
//       </section>

//       <footer className="footer">
//         <FaRegComments className="chat-icon" />
//         <a href="https://yourchatlink.com" target="_blank" rel="noopener noreferrer">
//           Online support chat
//         </a>
//       </footer>
//     </div>
//   );
// }

// export default LandingPage;
import React, { useState } from 'react';
import './LandingPage.css';
import { FaRegComments } from 'react-icons/fa'; 
import { Button, Drawer, Sidebar, TextInput, Label, Textarea } from "flowbite-react";
import { HiMail, HiInformationCircle, HiLogin, HiSearch, HiPaperClip, HiOutlineMenu } from "react-icons/hi";

function LandingPage() {

  const [isOpen, setIsOpen] = useState(false);
  const [formData, setFormData] = useState({
    fullName: '',
    email: '',
    resume: null,
  });
  const [showContactForm, setShowContactForm] = useState(false); 

  const handleClose = () => {
    setIsOpen(false); 
    setShowContactForm(false); 
  };

  const handleContactClick = () => {
    setShowContactForm(!showContactForm);
  };
  const handleChange = (e) => {
    const { name, value, files } = e.target;
    if (name === 'resume') {
      setFormData({
        ...formData,
        resume: files[0],
      });
    } else {
      setFormData({
        ...formData,
        [name]: value,
      });
    }
  };

  const handleDrawerClose = () => {
    setIsOpen(false);
  };

  const handleDrawerToggle = () => {
    setIsOpen(!isOpen);
  };

  return (
    <div className="landing-page">
      
      <header className="header">
        <h1>Express Tax</h1>
        <h2>Time is precious.</h2>
        <button className="order-btn">Book a taxi now</button>

        {/* כפתור המבורגר */}
        <div className="hamburger-icon">
          <button onClick={handleDrawerToggle} className="bg-transparent border-0 p-2 focus:outline-none">
            <HiOutlineMenu className="text-black text-2xl" />
          </button>
        </div>
      </header>

      <section className="features">
        <ul>
          <li>Taxis available within minutes</li>
          <li>Professional and experienced drivers</li>
          <li>24/6 service</li>
          <li>Real time taxi tracking</li>
        </ul>
      </section>

      <footer className="footer">
        <FaRegComments className="chat-icon" />
        <a href="https://yourchatlink.com" target="_blank" rel="noopener noreferrer">
          Online support chat
        </a>
      </footer>

      <Drawer open={isOpen} onClose={handleDrawerClose}>
        <Drawer.Items>
          <Sidebar
            aria-label="Sidebar with multi-level dropdown example"
            className="[&>div]:bg-transparent [&>div]:p-0"
          >
            <div className="flex h-full flex-col justify-between py-2">
              <form className="pb-3 md:hidden">
                <TextInput icon={HiSearch} type="search" placeholder="Search" required size={32} />
              </form>
              <Sidebar.Items>
                <Sidebar.ItemGroup>
                  <Sidebar.Item href="/authentication/sign-in" icon={HiLogin}>
                    Sign in
                  </Sidebar.Item>
                </Sidebar.ItemGroup>
                <Sidebar.ItemGroup>
                  <Sidebar.Item href="https://github.com/themesberg/flowbite-react/issues" icon={HiInformationCircle}>
                    Help
                  </Sidebar.Item>
                </Sidebar.ItemGroup>
              </Sidebar.Items>
              <Sidebar.ItemGroup>
                <Sidebar.Item href="#" icon={HiMail} onClick={handleContactClick}>
                  Contact Us
                </Sidebar.Item>
              </Sidebar.ItemGroup>
              {showContactForm && (
                <form action="#" className="my-4 mx-4">
                  <div className="mb-6 mt-3">
                    <Label htmlFor="email" className="mb-2 block">
                      Your email
                    </Label>
                    <TextInput id="email" name="email" placeholder="name@company.com" type="email" />
                  </div>
                  <div className="mb-6">
                    <Label htmlFor="subject" className="mb-2 block">
                      Subject
                    </Label>
                    <TextInput id="subject" name="subject" placeholder="Let us know how we can help you" />
                  </div>
                  <div className="mb-6">
                    <Label htmlFor="message" className="mb-2 block">
                      Your message
                    </Label>
                    <Textarea id="message" name="message" placeholder="Your message..." rows={4} />
                  </div>

                  <div className="mb-6 flex items-center">
                    <input 
                      type="file" 
                      id="file" 
                      name="file" 
                      accept="image/*,application/pdf" 
                      className="hidden" 
                      onChange={(e) => console.log(e.target.files)} 
                    />
                    <label htmlFor="file">
                      <Button className="">
                        <HiPaperClip className="mr-2" /> 
                        Attach a file
                      </Button>
                    </label>
                  </div>

                  <div className="">
                    <Button type="submit" className="w-full">
                      Send message
                    </Button>
                  </div>
                  <p className="mb-2 text-sm text-gray-500 dark:text-gray-400">
                    <a href="mailto:info@company.com" className="hover:underline">
                      info@company.com
                    </a>
                  </p>
                  <p className="text-sm text-gray-500 dark:text-gray-400">
                    <a href="tel:2124567890" className="hover:underline">
                      212-456-7890
                    </a>
                  </p>
                </form>
              )}

            </div>
          </Sidebar>
        </Drawer.Items>
      </Drawer>
    </div>
  );
}

export default LandingPage;