from google.cloud import texttospeech
from google.oauth2 import service_account

# Instantiates a client
client_file = 'studied-point-387806-5ffc51a0470f.json'
credentials = service_account.Credentials.from_service_account_file(client_file)
client = texttospeech.TextToSpeechClient(credentials=credentials)

def list_voices():
    """Lists the available voices."""
    # Performs the list voices request
    voices = client.list_voices()

    with open("output.txt", "w") as file:
        for voice in voices.voices:
            # Write the voice's name to the file
            file.write(f"Name: {voice.name}\n")

            # Write the supported language codes for this voice to the file
            for language_code in voice.language_codes:
                file.write(f"Supported language: {language_code}\n")

            ssml_gender = texttospeech.SsmlVoiceGender(voice.ssml_gender)

            # Write the SSML Voice Gender to the file
            file.write(f"SSML Voice Gender: {ssml_gender.name}\n")

            # Write the natural sample rate hertz for this voice to the file
            file.write(f"Natural Sample Rate Hertz: {voice.natural_sample_rate_hertz}\n\n")

# Call the list_voices function
list_voices()
