from google.cloud import texttospeech
from google.oauth2 import service_account

# Instantiates a client
client_file = 'studied-point-387806-5ffc51a0470f.json'
credentials = service_account.Credentials.from_service_account_file(client_file)
client = texttospeech.TextToSpeechClient(credentials=credentials)

# Set the text input to be synthesized
synthesis_input = texttospeech.SynthesisInput(text="You're welcome. Have a safe and pleasant flight!")

# Build the voice request, select the language code ("en-US") and the ssml
# voice gender ("male")
voice = texttospeech.VoiceSelectionParams(
    language_code="en-US", ssml_gender=texttospeech.SsmlVoiceGender.MALE
)

# Select the type of audio file you want returned
audio_config = texttospeech.AudioConfig(
    audio_encoding=texttospeech.AudioEncoding.MP3
)

# Perform the text-to-speech request on the text input with the selected
# voice parameters and audio file type
response = client.synthesize_speech(
    input=synthesis_input, voice=voice, audio_config=audio_config
)

# The response's audio_content is binary.
with open("output.mp3", "wb") as out:
    # Write the response to the output file.
    out.write(response.audio_content)
    print('Audio content written to file "output.mp3"')
