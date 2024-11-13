import ChatBot from 'react-chatbotify'
import { useState } from 'react'
import { HiX } from 'react-icons/hi';


function HelpChatBot({onClose}) {
  const [count, setCount] = useState(0)
  const flow = {
    "start": {
      "message": "Hello to you!\nwe are so glad you prefer ride on our taxis\nhow can I help you?"
    }
  }
  return (
    <>
    <div id='helpChat'>
    <button className="modal-close" onClick={onClose}>
          <div className="close-circle">
            <HiX className="close-icon" />
          </div>
        </button>
      <ChatBot flow={flow}/>
    </div>
    </>
  )
}

export default HelpChatBot;