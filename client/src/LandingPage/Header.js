// import { HiOutlineMenu } from "react-icons/hi";

// function Header({ isOpen, onDrawerToggle }) {
//   return (
//     <header className="header">
//       <h1>Express Tax</h1>
//       <h2>Time is precious.</h2>
//       <button className="order-btn">Book a taxi now</button>
      
//             {!isOpen && (
//         <div className="hamburger-icon">
//           <button onClick={onDrawerToggle} className="bg-transparent border-0 p-2 focus:outline-none">
//             <HiOutlineMenu className="text-black text-2xl" />
//           </button>
//         </div>
//       )}
//     </header>
//   );
// }

// export default Header;
import React, { useState } from 'react';
import { HiOutlineMenu } from "react-icons/hi";
import BookRide from '../Customer/BookRide';

function Header({ isOpen, onDrawerToggle }) {
  const [isModalOpen, setIsModalOpen] = useState(false);

  const toggleModal = () => {
    setIsModalOpen(!isModalOpen);
  };

  return (
    <header className="header">
       <h1>Faxi</h1>
       <h2>fast taxi</h2>
      <button onClick={toggleModal} className="order-btn">Book a taxi now</button>
      
      {!isOpen && (
        <div className="hamburger-icon">
          <button onClick={onDrawerToggle} className="bg-transparent border-0 p-2 focus:outline-none">
            <HiOutlineMenu className="text-black text-2xl" />
          </button>
        </div>
      )}

      {/* קומפוננטת המודל */}
      <BookRide isOpen={isModalOpen} onClose={toggleModal} />
    </header>
  );
}

export default Header;
